using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xulqna.Domain.Commons;
using Xulqna.Domain.Entities.Students;
using Xulqna.Service.DTOs.Students;

namespace Xulqna.Service.Interfaces
{
    public interface IStudentService
    {
        Task<BaseResponse<Student>> CreateAsync(StudentForCreationDto studentDto);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Student, bool>> expression);

        Task<BaseResponse<Student>> GetAsync(Expression<Func<Student, bool>> expression);
        Task<BaseResponse<IEnumerable<Student>>> GetAllAsync(Expression<Func<Student, bool>> expression = null);

        Task<BaseResponse<Student>> UpdateAsync(Guid id, StudentForCreationDto studentDto);

    }
}
