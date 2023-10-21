using SRV.Api.Models;
using System.Linq.Expressions;

namespace SRV.Api.Services
{
    public interface IStudentRepository
    {
        Task<StudentWithCoursesDtoGet> GetStudentAndEnrolledCoursesAsync(int studentId);
        Task<StudentDtoForGet> GetStudentByIdAsync(int studentId);
        Task DeleteCoursesEnrolled(int studentId, CourseArgs courseArgs);
        Task<List<YearAndTerm>> GetAademicYearsAndAcademicTermsACourseIsOffered(int studentId, int courseLevel, string courseCode);
        Task UpdatStudentEnrolledCourse(int studentId, CurrentAndNewCourseDetails courseArgs);
        Task<List<OrganizationDto>> GetOrganizations();
        Task<List<DepartmentDto>> GetDepartmentsbyOrganizationId(int organizationId);
        Task<List<ProgramDto>> GetProgramsByDepartmentId(int organizationId);
        Task<List<AcademicCalendarDetailOptionsDto>> GetAcademicCalendarDetailsByAcademicTermId(int programId);
        Task<int> AddStudent(AddStudentDto addStudentDto);
        IQueryable<T> Get<T>(Expression<Func<T, bool>> queryPredicate) where T : class;
        Task<List<CourseDto>> GetCoursesThatTheStudentCouldHaveEnrolled(int studentId);
        Task<int> AddStudentCourse(int studentId, AddEnrolledCourseRequestDto addEnrolledCourseRequestDto);
    }
}