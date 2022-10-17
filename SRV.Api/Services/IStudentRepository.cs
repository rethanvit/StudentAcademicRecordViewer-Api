using SRV.DL;

namespace SRV.Api.Services
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(int Id);
    }
}