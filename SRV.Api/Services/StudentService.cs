using SRV.Api.Models;

namespace SRV.Api.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDtoForGet> GetStudentByIdAsync(int studentId)
        {
            var studentDto = await _studentRepository.GetStudentByIdAsync(studentId);
            return studentDto;
        }
    }
}
