using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SRV.Api.Models;
using SRV.DL;

namespace SRV.Api.Services
{
    internal class StudentRepository:IStudentRepository
    {
        private readonly StudentContext _studentContext;
        private readonly IMapper _mapper;

        public StudentRepository(StudentContext studentContext, IMapper mapper)
        {
            _studentContext = studentContext;
            _mapper = mapper;
        }

        public async Task<StudentDtoForGet> GetStudentByIdAsync(int id)
        {
            var studentEntity = await _studentContext.Students.Where(s => s.Id == id).SingleOrDefaultAsync();
            return _mapper.Map<StudentDtoForGet>(studentEntity);
        }

        public async Task<StudentWithCoursesDtoGet> GetStudentAndCoursesByIdAsync(int id)
        {
            var studentWithCourses = await _studentContext.Students.Include(s => s.EnrolledCourses).ThenInclude(c => c.OfferedCoursesInTerm).ThenInclude(d => d.Course)
                                                                   .Include(s => s.EnrolledCourses).ThenInclude(c => c.OfferedCoursesInTerm).ThenInclude(d => d.AcademicTermDetail)
                                                                   .Include(s => s.Department).AsSplitQuery()
                                                                   .Where(s => s.Id == id).SingleOrDefaultAsync();
            return _mapper.Map<StudentWithCoursesDtoGet>(studentWithCourses);

        }
    }
}
