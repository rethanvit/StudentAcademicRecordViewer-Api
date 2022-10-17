using Microsoft.EntityFrameworkCore;
using SRV.DL;

namespace SRV.Api.Services
{
    internal class StudentRepository:IStudentRepository
    {
        private readonly StudentContext _studentContext;

        public StudentRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentContext.Students.Where(s => s.Id == id).SingleOrDefaultAsync();
        }
    }
}
