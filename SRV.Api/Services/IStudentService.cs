using SRV.Api.Models;

namespace SRV.Api.Services
{
    public interface IStudentService
    {
        Task<StudentDtoForGet> GetStudentByIdAsync(int id);
    }
}