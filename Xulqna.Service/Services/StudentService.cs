using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xulqna.Data.IRepositories;
using Xulqna.Domain.Commons;
using Xulqna.Domain.Configuration;
using Xulqna.Domain.Entities.Students;
using Xulqna.Service.DTOs.Students;
using Xulqna.Service.Extensions;
using Xulqna.Service.Interfaces;

namespace Xulqna.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IGroupRepository groupRepository;

        public StudentService(IStudentRepository studentRepository, IGroupRepository groupRepostiroy)
        {
            this.studentRepository = studentRepository;
            this.groupRepository = groupRepostiroy;
        }

        public async Task<BaseResponse<Student>> CreateAsync(StudentForCreationDto studentDto)
        {
            var response = new BaseResponse<Student>();

            var existStudent = await studentRepository.GetAsync(p => p.Phone == studentDto.Phone);

            // Check for Student
            if (existStudent is not null)
            {
                response.Error = new ErrorResponse(400, "Student exists!");
                return response;
            }

            // Check for group
            var groupStudent = await groupRepository.GetAsync(p => p.Id == studentDto.GroupId);
            if (groupStudent is null)
            {
                response.Error = new ErrorResponse(404, "Group not found!");
                return response;
            }

            // Create after checking success
            var mappedStudent = new Student
            {
                Firstname = studentDto.Firstname,
                Lastname = studentDto.Lastname,
                Phone = studentDto.Phone,
                GroupId = studentDto.GroupId
            };


            var entity = await studentRepository.CreateAsync(mappedStudent);


            response.Data = entity;

            return response;

        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Student, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            var existStudent = await studentRepository.GetAsync(expression);    
            if(existStudent is null)
            {
                response.Error = new ErrorResponse(404, "Student not found");
                return response;
            }    

            var result = await studentRepository.UpdateAsync(existStudent);
           
         

            response.Code = 200;
            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Student>>> GetAllAsync(PaginationParams @params,  Expression<Func<Student, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Student>>();

            var students = await studentRepository.GetAllAsync(expression);

            response.Code = 200;
            response.Data = students.ToPagedList(@params);

            return response;
        }

        public async Task<BaseResponse<Student>> GetAsync(Expression<Func<Student, bool>> expression)
        {
            var response = new BaseResponse<Student>();

            var student = await studentRepository.GetAsync(expression);

            if(student is  null)
            {
                response.Error = new ErrorResponse(404, "Student not found");
                return response;
            }

            response.Code = 200;
            response.Data = student;

            return response;

             
        }

        public async Task<BaseResponse<Student>> UpdateAsync(Guid id, StudentForCreationDto studentDto)
        {
            var response = new BaseResponse<Student>();

            var student = await studentRepository.GetAsync(p => p.Id == id);

            if(student is null)
            {
                response.Error = new ErrorResponse(404, "Student not found");
                return response;
            }

            var groupStudent = await groupRepository.GetAsync(p => p.Id == studentDto.GroupId);
            if(groupStudent is null)
            {
                response.Error = new ErrorResponse(404, "Group not found");
            }

            var mappedStudent = new Student
            {
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Phone = student.Phone,
                GroupId = student.GroupId
            };

            mappedStudent.Update();

            var result = await studentRepository.UpdateAsync(mappedStudent);

            response.Code = 200;
            response.Data = result;
           
            return response;
        }
    }
}
