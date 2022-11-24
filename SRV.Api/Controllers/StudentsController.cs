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
        public async Task<ActionResult<StudentDtoForGet>> Get(int organizationId, int studentId)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentId);
            if(student == null)
                return NotFound("Provided student doesn't exist.");

            return Ok(student);
        }

        [HttpGet("{organizationId:int}/{studentId:int}/withCourses")]
        public async Task<ActionResult<StudentWithCoursesDtoGet>> GetStudentWithCourses(int organizationId, int studentId)
        {
            var student = await _studentRepository.GetStudentAndCoursesByIdAsync(studentId);

            if (student == null)
                return NotFound("Provided student doesn't exist.");

            return Ok(student);
        }

        [HttpDelete("{organizationId:int}/{studentId:int}/EnrolledCourse")]
        public async Task<IActionResult> DeleteEnrolledCourse(int organizationId, int studentId, [FromBody]CourseArgs courseArgs)
        {
            await _studentRepository.DeleteCoursesEnrolled(studentId, courseArgs);
            return Ok();

        }

        [HttpGet("{organizationId:int}/{studentId:int}/EnrolledCourse/{courseCode:alpha}/{courseLevel:int}")]
        public async Task<IActionResult> GetEditEnrolledCourseOptions(int organizationId, int studentId, string courseCode, int courseLevel)
        {
            await _studentRepository.GetAademicYearsAndAcademicTermsACourseIsOffered(studentId, courseLevel, courseCode);
            return Ok();

        }

    }
}
