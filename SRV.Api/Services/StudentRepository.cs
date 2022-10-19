using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            //var studentWithCourses = await _studentContext.Students.Include(s => s.EnrolledCourses).ThenInclude(c => c.OfferedCoursesInTerm).ThenInclude(d => d.Course)
            //                                                       .Include(s => s.EnrolledCourses).ThenInclude(c => c.OfferedCoursesInTerm).ThenInclude(d => d.AcademicTermDetail)
            //                                                       .Include(s => s.Department)/*.AsSplitQuery()*/
            //                                                       .Where(s => s.Id == id).SingleOrDefaultAsync();

            //var test = await _studentContext.Students.Join(_studentContext.EnrolledCourses, s => s.Id, ec => ec.StudentId, (s, ec) => new { s, ec})
            //                                         .Join(_studentContext.OfferedCoursesInTerms, sec => sec.ec.OfferedCoursesInTermId, oc => oc.Id, (sec, oc) => new { sec, oc })
            //                                         .Join(_studentContext.Courses, secoc => secoc.oc.CourseId, c => c.Id, (secoc, c) => new { secoc, c })
            //                                         .Join(_studentContext.AcademicTermDetails, secocc => secocc.secoc.oc.AcademicTermDetailId, atd => atd.Id, (secocc, atd) => new { secocc, atd})
            //                                         .Join(_studentContext.Departments, secoccatd => secoccatd.secocc.c.DepartmentId, d => d.Id, 
            //                                                                            (secoccatd, d) => new 
            //                                                                            { 
            //                                                                              secoccatd.secocc.secoc.sec.s.Id,
            //                                                                              secoccatd.secocc.secoc.sec.s.FirstName, 
            //                                                                              secoccatd.secocc.secoc.sec.s.LastName,
            //                                                                              secoccatd.secocc.c.Code, 
            //                                                                              CourseName = secoccatd.secocc.c.Name,
            //                                                                              DepartmentName = d.Name, 
            //                                                                              secoccatd.secocc.secoc.sec.ec.Marks 
            //                                                                            }).Where(filtered => filtered.Id == 1).ToListAsync();

            //var test1 = (from student in _studentContext.Students 
            //            join enrolledCourse in _studentContext.EnrolledCourses
            //            on student.Id equals enrolledCourse.StudentId
            //            into studentEnrolledCourses
            //            from studentEnrolledCourse in studentEnrolledCourses.DefaultIfEmpty()
            //            join offeredCourseInTerm in _studentContext.OfferedCoursesInTerms
            //            on studentEnrolledCourse.OfferedCoursesInTermId equals offeredCourseInTerm.Id
            //            join academicTermDetail in _studentContext.AcademicTermDetails
            //            on offeredCourseInTerm.AcademicTermDetailId equals academicTermDetail.Id
            //            join course in _studentContext.Courses
            //            on offeredCourseInTerm.CourseId equals course.Id
            //            join department in _studentContext.Departments
            //            on course.DepartmentId equals department.Id
            //            select new { student.Id, student.FirstName, student.LastName, course.Code, courseName = course.Name, departmentName = department.Name, academicTermDetail.Year, academicTermDetail.Term, studentEnrolledCourse.Marks }).ToList();

            var studentEntityWithCourses = 
                await (from student in _studentContext.Students
                join studentEC in (from enrolledCourse in _studentContext.EnrolledCourses
                         join offeredCourseInTerm in _studentContext.OfferedCoursesInTerms
                         on enrolledCourse.OfferedCoursesInTermId equals offeredCourseInTerm.Id
                         join academicTermDetail in _studentContext.AcademicTermDetails
                         on offeredCourseInTerm.AcademicTermDetailId equals academicTermDetail.Id
                         join course in _studentContext.Courses
                         on offeredCourseInTerm.CourseId equals course.Id
                         join department in _studentContext.Departments
                         on course.DepartmentId equals department.Id
                         where enrolledCourse.StudentId == id
                         select new { enrolledCourse.StudentId, course.Code, courseName = course.Name, departmentName = department.Name, academicTermDetail.Year, academicTermDetail.Term, enrolledCourse.Marks })
                 on student.Id equals studentEC.StudentId
                 into CoursesEnrolledByStudents
                 from coursesEnrolledByStudent in CoursesEnrolledByStudents.DefaultIfEmpty()
                 where student.Id == id
                 select new { student.Id, student.FirstName, student.LastName, coursesEnrolledByStudent.Code, coursesEnrolledByStudent.courseName, coursesEnrolledByStudent.departmentName, Year = (int?)coursesEnrolledByStudent.Year, Term = (int?)coursesEnrolledByStudent.Term, Marks = (double?) coursesEnrolledByStudent.Marks }).ToListAsync();

            StudentWithCoursesDtoGet studentWithCourseDetailsDto = null;
            studentEntityWithCourses.ForEach(s => {
                if (studentWithCourseDetailsDto == null) studentWithCourseDetailsDto = new StudentWithCoursesDtoGet();
                if (!studentWithCourseDetailsDto.Id.Equals(s.Id))
                    studentWithCourseDetailsDto = new StudentWithCoursesDtoGet { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName };
                if (s.Code != null)
                {
                    studentWithCourseDetailsDto.EnrolledCourses.Add(new EnrolledCourseDetailsDto { Code = s.Code, Name = s.courseName, 
                        Department = s.departmentName, AcademicTerm = s.Term.Value, AcademicYear = s.Year.Value, Marks = s.Marks.Value });
                }
            });
            return studentWithCourseDetailsDto;

        }
    }
}
