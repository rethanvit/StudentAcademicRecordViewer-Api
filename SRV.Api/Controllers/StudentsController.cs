using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRV.Api.Filters;
using SRV.Api.Models;
using SRV.Api.Services;
using SRV.DL;

namespace SRV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var student = await _studentRepository.GetStudentAndEnrolledCoursesAsync(studentId);

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
            var yearAndAcademicTermsTheCourseWasOffered = await _studentRepository.GetAademicYearsAndAcademicTermsACourseIsOffered(studentId, courseLevel, courseCode);
            return Ok(yearAndAcademicTermsTheCourseWasOffered);

        }

        [HttpPut("{organizationId:int}/{studentId:int}/EnrolledCourse")]
        public async Task<IActionResult> UpdateEnrolledCourse(int organizationId, int studentId, [FromBody]UpdateCourseArgs courseArgs)
        {
            await _studentRepository.UpdatStudentEnrolledCourse(studentId, courseArgs.updateCourseArgs);
            return Ok();
        }

        [HttpGet("organizations")]
        public async Task<ActionResult<DepartmentDto>> GetOrganizations()
        {
            var departments = await _studentRepository.GetOrganizations();
            return Ok(departments);
        }

        [HttpGet("organization/{organizationId:int}/departments")]
        public async Task<ActionResult<DepartmentDto>> GetDepartments(int organizationId)
        {
            var departments = await _studentRepository.GetDepartmentsbyOrganizationId(organizationId);
            return Ok(departments);
        }

        [HttpGet("department/{departmentId:int}/programs")]
        public async Task<ActionResult<ProgramDto>> GetPrograms(int departmentId)
        {
            var programs = await _studentRepository.GetProgramsByDepartmentId(departmentId);
            return Ok(programs);
        }

        [HttpGet("academicCalendarDetails/{programId:int}")]
        public async Task<ActionResult<AcademicCalendarDetailOptionsDto>> GetAcademicCalendarDetailOptions(int programId)
        {
            var academicCalendarDetailOptions = await _studentRepository.GetAcademicCalendarDetailsByAcademicTermId(programId);
            return Ok(academicCalendarDetailOptions);
        }

        [HttpPost("addStudent")]
        [RoleCheck(Constants.RoleAdmin)]
        public async Task<ActionResult<int>> AddStudent(AddStudentDto addStudent)
        {
            if(!_studentRepository.Get<AcademicCalendarDetail>(c => c.AcademicCalendarDetailId == addStudent.AcademicDetailsStartId).Any())
            {
                return BadRequest("Invalid student academic start provided");
            }
            if (!_studentRepository.Get<DL.Program>(p => p.ProgramId == addStudent.ProgramId).Any())
            {
                return BadRequest("Invalid program provided");
            }
            var addStudentResult = await _studentRepository.AddStudent(addStudent);
            return Ok(addStudentResult);
        }

        [HttpGet("courseOptions/{studentId:int}")]
        public async Task<ActionResult> GetCoursesOptions(int studentId)
        {
            var test = await _studentRepository.GetCoursesThatTheStudentCouldHaveEnrolled(studentId);
            return Ok(test);
        }

        [HttpPost("addEnrolledCourse/{studentId:int}")]
        public async Task<ActionResult> AddEnrolledCourse(int studentId, AddEnrolledCourseRequestDto addEnrolledCourseRequestDto)
        {
            var test = await _studentRepository.AddStudentCourse(studentId, addEnrolledCourseRequestDto);
            return Ok(test);
        }

    }
}
