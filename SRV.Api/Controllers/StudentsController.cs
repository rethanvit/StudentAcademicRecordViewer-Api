using Microsoft.AspNetCore.Mvc;
using SRV.Api.Models;
using SRV.Api.Services;

namespace SRV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("{organizationId:int}/{studentId:int}")]
        //[Route("courses/test")]
        public async Task<ActionResult<StudentDtoForGet>> Get(int organizationId, int studentId)
        {
            var student = await _studentRepository.GetStudentByIdAsync(organizationId, studentId);

            if(student == null)
                return NotFound("Provided student doesn't exist.");

            return Ok(student);
        }

        [HttpGet("{organizationId:int}/{studentId:int}/withCourses")]
        public async Task<ActionResult<StudentWithCoursesDtoGet>> GetStudentWithCourses(int organizationId, int studentId)
        {
            var student = await _studentRepository.GetStudentAndCoursesByIdAsync(organizationId, studentId);

            if (student == null)
                return NotFound("Provided student doesn't exist.");

            return Ok(student);
        }

    }
}
