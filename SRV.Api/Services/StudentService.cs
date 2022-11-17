using AutoMapper;
using SRV.Api.Models;

namespace SRV.Api.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentDtoForGet> GetStudentByIdAsync(int organizationId, int studentId)
        {
            var studentDto = await _studentRepository.GetStudentByIdAsync(organizationId, studentId);
            return _mapper.Map<StudentDtoForGet>(studentDto);
        }
    }
}
