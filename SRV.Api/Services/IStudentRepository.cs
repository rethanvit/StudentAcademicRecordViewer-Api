using SRV.Api.Models;

namespace SRV.Api.Services
{
    public interface IStudentRepository
    {
        Task<StudentWithCoursesDtoGet> GetStudentAndCoursesByIdAsync(int studentId);
        Task<StudentDtoForGet> GetStudentByIdAsync(int studentId);
        Task DeleteCoursesEnrolled(int studentId, CourseArgs courseArgs);
        Task GetAademicYearsAndAcademicTermsACourseIsOffered(int studentId, int courseLevel, string courseCode);
    }
}