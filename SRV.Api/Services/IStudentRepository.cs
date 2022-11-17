using SRV.Api.Models;

namespace SRV.Api.Services
{
    public interface IStudentRepository
    {
        Task<StudentWithCoursesDtoGet> GetStudentAndCoursesByIdAsync(int id);
        Task<StudentDtoForGet> GetStudentByIdAsync(int id);
    }
}