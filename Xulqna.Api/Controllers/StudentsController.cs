using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xulqna.Domain.Commons;
using Xulqna.Domain.Entities.Students;
using Xulqna.Service.DTOs.Students;
using Xulqna.Service.Interfaces;

namespace Xulqna.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Student>>> Create(StudentForCreationDto studentDto)
        {
            var result = await studentService.CreateAsync(studentDto);

            return StatusCode(result?.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Student>>>> GetAll()
        {
            var result = await studentService.GetAllAsync();

            return StatusCode(result?.Code ?? result.Error.Code.Value, result);
        }
        
    }
}
