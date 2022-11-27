using SRV.Api.Models;

namespace SRV.Api.Services
{
    public interface IStudentRepository
    {
        Task<StudentWithCoursesDtoGet> GetStudentAndCoursesByIdAsync(int studentId);
        Task<StudentDtoForGet> GetStudentByIdAsync(int studentId);
        Task DeleteCoursesEnrolled(int studentId, CourseArgs courseArgs);
        Task<List<YearAndTerm>> GetAademicYearsAndAcademicTermsACourseIsOffered(int studentId, int courseLevel, string courseCode);
        Task UpdatStudentEnrolledCourse(int studentId, CurrentAndNewCourseDetails courseArgs);
    }
}