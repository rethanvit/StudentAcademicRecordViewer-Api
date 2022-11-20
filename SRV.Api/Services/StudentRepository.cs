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

        public async Task<StudentDtoForGet> GetStudentByIdAsync(int organizationId, int id)
        {
            //var studentEntity = await _studentContext.Students.Where(s => s.Id == id).Include(s => s.Department).Include(s => s.Organization).SingleOrDefaultAsync();
            var studentInfo = await _studentContext.Students.Join(_studentContext.Programs, s => s.ProgramId, p => p.ProgramId, (s, p) => new { s, p })
                                                            .Join(_studentContext.Departments, sp => sp.p.DepartmentId, d => d.DepartmentId, (sp, d) => new { sp, d })
                                                            .Join(_studentContext.Organizations, spd => spd.d.OrganizationId, o => o.OrganizationId, (spd, o) => new {spd, o } )
                                                            .Where(spdo => spdo.o.OrganizationId == organizationId && spdo.spd.sp.s.StudentId == id)
                                                            .Select(spdo => new  StudentDtoForGet { StudentId = spdo.spd.sp.s.StudentId, 
                                                                                                   FirstName = spdo.spd.sp.s.FirstName, 
                                                                                                   LastName = spdo.spd.sp.s.LastName,
                                                                                                   DepartmentId = spdo.spd.d.DepartmentId,
                                                                                                   Department = spdo.spd.d.Name,
                                                                                                   Program = spdo.spd.sp.p.Name,
                                                                                                   OrganizationId = spdo.o.OrganizationId,
                                                                                                   Organization = spdo.o.Name 
                                                                                                 }).SingleOrDefaultAsync();
                                                      

            return studentInfo;
        }

        public async Task<StudentWithCoursesDtoGet> GetStudentAndCoursesByIdAsync(int organizationId, int id)
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
                       join program in _studentContext.Programs
                       on student.ProgramId equals program.ProgramId
                       join department in _studentContext.Departments
                       on program.DepartmentId equals department.DepartmentId
                       join organization in _studentContext.Organizations
                       on department.OrganizationId equals organization.OrganizationId
                       where student.StudentId == id && department.OrganizationId == organizationId
                       join studentEC in (from enrolledCourse in _studentContext.EnrolledCourses
                                          join offeredCourse in _studentContext.OfferedCourses
                                          on enrolledCourse.OfferedCourseId equals offeredCourse.OfferedCourseId
                                          join academicCalendarDetail in _studentContext.AcademicCalendarDetails
                                          on offeredCourse.AcademicCalendarDetailId equals academicCalendarDetail.AcademicCalendarDetailId
                                          join refAcademicCalendar in _studentContext.AcademicCalendars
                                          on academicCalendarDetail.AcademicCalendarId equals refAcademicCalendar.AcademicCalendarId
                                          join course in _studentContext.Courses
                                          on offeredCourse.CourseId equals course.CourseId
                                          join program in _studentContext.Programs
                                          on course.ProgramId equals program.ProgramId
                                          join department in _studentContext.Departments
                                          on program.DepartmentId equals department.DepartmentId
                                          where enrolledCourse.StudentId == id
                                          select new { enrolledCourse.StudentId, enrolledCourse.EnrolledCourseId, departmentName = department.Name, course.Code, courseName = course.Name, academicCalendarDetail.Year, termName = refAcademicCalendar.Name, enrolledCourse.Marks })
                        on student.StudentId equals studentEC.StudentId
                        into CoursesEnrolledByStudents
                       from coursesEnrolledByStudent in CoursesEnrolledByStudents.DefaultIfEmpty()
                       select new { student.StudentId, student.FirstName, student.LastName, coursesEnrolledByStudent.EnrolledCourseId, coursesEnrolledByStudent.Code, coursesEnrolledByStudent.courseName, coursesEnrolledByStudent.departmentName, Year = coursesEnrolledByStudent.Year, Term = coursesEnrolledByStudent.termName, Marks = (double?)coursesEnrolledByStudent.Marks }).ToListAsync();

            StudentWithCoursesDtoGet studentWithCourseDetailsDto = null;
            studentEntityWithCourses.ForEach(s =>
            {
                if (studentWithCourseDetailsDto == null) studentWithCourseDetailsDto = new StudentWithCoursesDtoGet();
                if (!studentWithCourseDetailsDto.StudentId.Equals(s.StudentId))
                    studentWithCourseDetailsDto = new StudentWithCoursesDtoGet { StudentId = s.StudentId, FirstName = s.FirstName, LastName = s.LastName };
                if (s.Code != null)
                {
                    studentWithCourseDetailsDto.CoursesEnrolled.Add(new EnrolledCourseDetailsDto
                    {
                        EnrolledCourseId = s.EnrolledCourseId,
                        Code = s.Code,
                        Name = s.courseName,
                        Department = s.departmentName,
                        AcademicTerm = s.Term,
                        AcademicYear = s.Year,
                        Marks = s.Marks.Value
                    });
                }
            });
            return studentWithCourseDetailsDto;
            //return null;

        }

        public async Task DeleteCoursesEnrolled(int organizationId, int studentId, int enrolledCourseId)
        {
            var courseDeleted = await _studentContext.EnrolledCourses.Where(ec => ec.EnrolledCourseId == enrolledCourseId).SingleOrDefaultAsync<EnrolledCourse>();
            
            if(courseDeleted != null)
            {
                _studentContext.EnrolledCourses.Remove(courseDeleted);
                await _studentContext.SaveChangesAsync();
            }
        }

    }
}
