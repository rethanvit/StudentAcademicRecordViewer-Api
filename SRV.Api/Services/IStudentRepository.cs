using SRV.Api.Models;

namespace SRV.Api.Services
{
    public interface IStudentRepository
    {
        Task<StudentWithCoursesDtoGet> GetStudentAndCoursesByIdAsync(int organizationId, int id);
        Task<StudentDtoForGet> GetStudentByIdAsync(int organizationId, int id);
        Task DeleteCoursesEnrolled(int organizationId, int studentId, int enrolledCourseId);
    }
}