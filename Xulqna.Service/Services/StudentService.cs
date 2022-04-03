
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xulqna.Data.IRepositories;
using Xulqna.Domain.Commons;
using Xulqna.Domain.Entities.Students;
using Xulqna.Service.DTOs.Students;
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
            mappedStudent.Update();

            var entity = await studentRepository.CreateAsync(mappedStudent);


            response.Data = entity;

            return response;

        }

        public Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<IEnumerable<Student>>> GetAllAsync(Expression<Func<Student, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Student>>();

            var students = await studentRepository.GetAllAsync(expression);

            response.Code = 200;
            response.Data = students;

            return response;
        }

        public Task<BaseResponse<Student>> GetAsync(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Student>> UpdateAsync(Guid id, StudentForCreationDto studentDto)
        {
            throw new NotImplementedException();
        }
    }
}
