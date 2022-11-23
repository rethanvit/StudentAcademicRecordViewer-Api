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

        public async Task<StudentDtoForGet> GetStudentByIdAsync(int studentId)
        {
            //var studentEntity = await _studentContext.Students.Where(s => s.Id == id).Include(s => s.Department).Include(s => s.Organization).SingleOrDefaultAsync();
            var studentInfo = await _studentContext.Students.Join(_studentContext.Programs, s => s.ProgramId, p => p.ProgramId, (s, p) => new { s, p })
                                                            .Join(_studentContext.Departments, sp => sp.p.DepartmentId, d => d.DepartmentId, (sp, d) => new { sp, d })
                                                            .Join(_studentContext.Organizations, spd => spd.d.OrganizationId, o => o.OrganizationId, (spd, o) => new {spd, o } )
                                                            .Where(spdo => spdo.spd.sp.s.StudentId == studentId)
                                                            .Select(spdo => new  StudentDtoForGet { StudentId = spdo.spd.sp.s.StudentId, 
                                                                                                   FirstName = spdo.spd.sp.s.FirstName, 
                                                                                                   LastName = spdo.spd.sp.s.LastName,
                                                                                                   DepartmentName = spdo.spd.d.Name,
                                                                                                   DepartmentCode = spdo.spd.d.Code,
                                                                                                   ProgramCode = spdo.spd.sp.p.Code,
                                                                                                   ProgramName = spdo.spd.sp.p.Name,
                                                                                                   OrganizationName = spdo.o.Name 
                                                                                                 }).SingleOrDefaultAsync();
                                                      

            return studentInfo;
        }

        public async Task<StudentWithCoursesDtoGet> GetStudentAndCoursesByIdAsync(int studentId)
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
                       where student.StudentId == studentId
                       join studentEC in (from enrolledCourse in _studentContext.EnrolledCourses
                                          join academicCalendarDetail in _studentContext.AcademicCalendarDetails
                                          on enrolledCourse.AcademicCalendarDetailId equals academicCalendarDetail.AcademicCalendarDetailId
                                          join refAcademicCalendar in _studentContext.AcademicCalendars
                                          on academicCalendarDetail.AcademicCalendarId equals refAcademicCalendar.AcademicCalendarId
                                          join course in _studentContext.Courses
                                          on enrolledCourse.CourseId equals course.CourseId
                                          join program in _studentContext.Programs
                                          on course.ProgramId equals program.ProgramId
                                          join department in _studentContext.Departments
                                          on program.DepartmentId equals department.DepartmentId
                                          where enrolledCourse.StudentId == studentId
                                          select new { enrolledCourse.StudentId, departmentName = department.Name, course.Code, course.Level, courseName = course.Name, academicCalendarDetail.Year, termName = refAcademicCalendar.Name, enrolledCourse.Marks })
                        on student.StudentId equals studentEC.StudentId
                        into CoursesEnrolledByStudents
                       from coursesEnrolledByStudent in CoursesEnrolledByStudents.DefaultIfEmpty()
                       select new { student.StudentId, student.FirstName, student.LastName, coursesEnrolledByStudent.Code, coursesEnrolledByStudent.Level, coursesEnrolledByStudent.courseName, coursesEnrolledByStudent.departmentName, Year = coursesEnrolledByStudent.Year, Term = coursesEnrolledByStudent.termName, Marks = (double?)coursesEnrolledByStudent.Marks }).ToListAsync();

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
                        CourseCode = s.Code,
                        CourseName = s.courseName,
                        CourseLevel = s.Level,
                        DepartmentName = s.departmentName,
                        AcademicTerm = s.Term,
                        AcademicYear = s.Year,
                        Marks = s.Marks.Value
                    });
                }
            });
            return studentWithCourseDetailsDto;
            //return null;

        }

        public async Task DeleteCoursesEnrolled(StudentCourseArgs courseArgs)
        {
            var academicCalendarDetailIdInWhichCourseWasOffered = _studentContext.AcademicCalendarDetails.Join(_studentContext.AcademicCalendars, acd => acd.AcademicCalendarId, ac => ac.AcademicCalendarId, (acd, ac) => new { acd, ac })
                                                                       .Join(_studentContext.RefAcademicTerms, acdac => acdac.ac.AcademicTermId, at => at.AcademicTermId, (acdac, at) => new { acdac, at })
                                                                       .Where(acdacat => acdacat.at.AcademicTermId == _studentContext.Programs.Single(p => p.Code.Equals(courseArgs.StudentProgramCode)).AcademicTermId &&
                                                                              acdacat.acdac.ac.Name.Equals(courseArgs.AcademicTerm) &&
                                                                              acdacat.acdac.acd.AcademicCalendarDetailId >= _studentContext.Students.Include(s => s.AcademicCalendarDetail).Single(s => s.StudentId == courseArgs.StudentId).AcademicCalendarDetail.AcademicCalendarDetailId &&
                                                                              acdacat.acdac.acd.Year == courseArgs.Academicyear)
                                                                       .Select(acdacat => acdacat.acdac.acd.AcademicCalendarDetailId).Single();
            //var academicCourseDetailIdOfTheCourse = _studentContext.AcademicCalendarDetails.Join(_studentContext.OfferedCourses, acd => acd.AcademicCalendarDetailId, oc => oc.AcademicCalendarDetailId, (acd, oc) => new { acd, oc })
            //                                                                                .Where(acdoc => acdoc.oc.CourseId == _studentContext.Courses.Single(c => c.Code.Equals(courseArgs.CourseCode) && c.Level.Equals(courseArgs.CourseLevel)).CourseId &&
            //                                                                                       acdoc.acd.Year >= _studentContext.Students.Include(d => d.AcademicCalendarDetail).Single(s => s.StudentId == courseArgs.StudentId).AcademicCalendarDetail.Year).ToList();

            var courseDeleted = await _studentContext.EnrolledCourses.SingleAsync(ec => ec.CourseId == _studentContext.Courses.Single(c => c.Code.Equals(courseArgs.CourseCode) && c.Level == courseArgs.CourseLevel).CourseId && ec.StudentId == courseArgs.StudentId &&
                                                                            ec.AcademicCalendarDetailId == academicCalendarDetailIdInWhichCourseWasOffered);

            if (courseDeleted != null)
            {
                _studentContext.EnrolledCourses.Remove(courseDeleted);
                await _studentContext.SaveChangesAsync();
            }

        }

        public async Task GetAademicYearsAndAcademicTermsACourseIsOffered(int studentId, int courseLevel, string courseCode)
        {
            //var studentStartAcademicCalendar = _studentContext.AcademicCalendarDetails.Single(ac => ac.AcademicCalendarDetailId == _studentContext.Students.Single(s => s.StudentId == student.StudentId).AcademicCalendarDetailId);
            //var studentCurrentProgramDetails = _studentContext.Programs.Single(p => p.ProgramId == student.ProgramId);
            //var academicCalendarDetailsWhenCourseWasOffered = _studentContext.OfferedCourses.Where(oc => oc.CourseId == 1).Select(c => c.AcademicCalendarDetailId).ToList();

            ////var courseId = _studentContext.OfferedCourses.Single(oc => oc.OfferedCourseId == _studentContext.EnrolledCourses.Single(ec => ec.EnrolledCourseId == enrolledCourse.EnrolledCourseId).OfferedCourseId).CourseId;
            ////var academicCalendarDetailsIds = _studentContext.OfferedCourses.Where(oc => oc.OfferedCourseId == _studentContext.EnrolledCourses.Single(ec => ec.EnrolledCourseId == enrolledCourse.EnrolledCourseId).OfferedCourseId).Select(c => c.AcademicCalendarDetailId).ToList();
            ////var years = _studentContext.AcademicCalendarDetails.Where(ac => academicCalendarDetailsIds.Contains(ac.AcademicCalendarId)).Select(c => c.Year).Distinct();
            ////var academicCalendarIds = _studentContext.AcademicCalendarDetails.Where(ac => academicCalendarDetailsIds.Contains(ac.AcademicCalendarId)).Select(c => c.AcademicCalendarId).Distinct();
            ////var academicCalendarNames = _studentContext.AcademicCalendars.Where(ac => academicCalendarIds.Contains(ac.AcademicCalendarId)).Select(c => c.Name).ToList();

            //var test = _studentContext.AcademicCalendarDetails.Join(_studentContext.AcademicCalendars, acd => acd.AcademicCalendarId, ac => ac.AcademicCalendarId, (acd, ac) => new { acd, ac })
            //                                                  .Join(_studentContext.RefAcademicTerms, acdac => acdac.ac.AcademicTermId, at => at.AcademicTermId, (acdac, at) => new { acdac, at })
            //                                                  .Join(_studentContext.Programs, acdacat => acdacat.at.AcademicTermId, p => p.AcademicTermId, (acdacat, p) => new { acdacat, p })
            //                                                  .Where(acdacatp => acdacatp.p.AcademicTermId == studentCurrentProgramDetails.AcademicTermId &&
            //                                                         acdacatp.p.ProgramId == studentCurrentProgramDetails.ProgramId &&
            //                                                         acdacatp.acdacat.acdac.acd.Year >= studentStartAcademicCalendar.Year &&
            //                                                         academicCalendarDetailsWhenCourseWasOffered.Contains(acdacatp.acdacat.acdac.acd.AcademicCalendarDetailId))
            //                                                  .Select(c => new { }).ToList();

            var academicCourseDetailIdOfTheCourse = _studentContext.AcademicCalendarDetails.Join(_studentContext.OfferedCourses, acd => acd.AcademicCalendarDetailId, oc => oc.AcademicCalendarDetailId, (acd, oc) => new { acd, oc })
                                                                                            .Where(acdoc => acdoc.oc.CourseId == _studentContext.Courses.Single(c => c.Code.Equals(courseCode) && c.Level.Equals(courseLevel)).CourseId &&
                                                                                                   acdoc.acd.Year >= _studentContext.Students.Include(d => d.AcademicCalendarDetail).Single(s => s.StudentId == studentId).AcademicCalendarDetail.Year).ToList();
        }

    }
}
