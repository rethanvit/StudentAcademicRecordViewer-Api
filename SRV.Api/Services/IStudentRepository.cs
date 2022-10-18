using SRV.Api.Models;
using SRV.DL;

namespace SRV.Api.Services
{
    public interface IStudentRepository
    {
        Task<StudentWithCoursesDtoGet> GetStudentAndCoursesByIdAsync(int id);
        Task<StudentDtoForGet> GetStudentByIdAsync(int id);
    }
}