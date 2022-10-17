using Microsoft.AspNetCore.Mvc;
using SRV.Api.Models;
using SRV.Api.Services;

namespace SRV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<StudentDtoForGet>> Get(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if(student == null)
                return NotFound("Provided student doesn't exist.");

            return Ok(student);
        }
    }
}
