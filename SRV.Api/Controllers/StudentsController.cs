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

        [HttpGet("{id:int}")]
        //[Route("courses/test")]
        public async Task<ActionResult<StudentDtoForGet>> Get(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);

            if(student == null)
                return NotFound("Provided student doesn't exist.");

            return Ok(student);
        }

        [HttpGet("{id:int}/withCourses")]
        public async Task<ActionResult<StudentWithCoursesDtoGet>> GetStudentWithCourses(int id)
        {
            var student = await _studentRepository.GetStudentAndCoursesByIdAsync(id);

            if (student == null)
                return NotFound("Provided student doesn't exist.");

            return Ok(student);
        }

    }
}
