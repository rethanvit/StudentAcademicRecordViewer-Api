using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SRV.Api.Models;
using SRV.DL;

namespace SRV.Api.Services
{
    internal class StudentRepository : IStudentRepository
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
            var studentInfo = await _studentContext.Students.Join(_studentContext.Programs, s => s.ProgramId, p => p.ProgramId, (s, p) => new { s, p })
                                                            .Join(_studentContext.Departments, sp => sp.p.DepartmentId, d => d.DepartmentId, (sp, d) => new { sp, d })
                                                            .Join(_studentContext.Organizations, spd => spd.d.OrganizationId, o => o.OrganizationId, (spd, o) => new { spd, o })
                                                            .Where(spdo => spdo.spd.sp.s.StudentId == studentId)
                                                            .Select(spdo => new StudentDtoForGet { StudentId = spdo.spd.sp.s.StudentId,
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
                       select new
                       {
                           student.StudentId,
                           student.FirstName,
                           student.LastName,
                           code = coursesEnrolledByStudent == null ? null : coursesEnrolledByStudent.Code,
                           level = coursesEnrolledByStudent == null ? null : (int?)coursesEnrolledByStudent.Level,
                           courseName = coursesEnrolledByStudent == null ? null : coursesEnrolledByStudent.courseName,
                           departmentName = coursesEnrolledByStudent == null ? null : coursesEnrolledByStudent.departmentName,
                           Year = coursesEnrolledByStudent == null ? null : (int?)coursesEnrolledByStudent.Year,
                           Term = coursesEnrolledByStudent == null ? null : coursesEnrolledByStudent.termName,
                           Marks = coursesEnrolledByStudent == null ? null : (double?)coursesEnrolledByStudent.Marks
                       }).ToListAsync();

            StudentWithCoursesDtoGet studentWithCourseDetailsDto = null;
            studentEntityWithCourses.ForEach(s =>
            {
                if (studentWithCourseDetailsDto == null) studentWithCourseDetailsDto = new StudentWithCoursesDtoGet();
                if (!studentWithCourseDetailsDto.StudentId.Equals(s.StudentId))
                    studentWithCourseDetailsDto = new StudentWithCoursesDtoGet { StudentId = s.StudentId, FirstName = s.FirstName, LastName = s.LastName };
                if (s.code != null)
                {
                    studentWithCourseDetailsDto.CoursesEnrolled.Add(new EnrolledCourseDetailsDto
                    {
                        CourseCode = s.code,
                        CourseName = s.courseName,
                        CourseLevel = s.level.Value,
                        DepartmentName = s.departmentName,
                        AcademicTerm = s.Term,
                        AcademicYear = s.Year.Value,
                        Marks = s.Marks.Value
                    });
                }
            });
            return studentWithCourseDetailsDto;
        }

        public async Task DeleteCoursesEnrolled(int studentId, CourseArgs courseArgs)
        {
            var academicCalendarDetailIdInWhichCourseWasOffered = await _studentContext.AcademicCalendarDetails.Join(_studentContext.AcademicCalendars, acd => acd.AcademicCalendarId, ac => ac.AcademicCalendarId, (acd, ac) => new { acd, ac })
                                                                       .Join(_studentContext.RefAcademicTerms, acdac => acdac.ac.AcademicTermId, at => at.AcademicTermId, (acdac, at) => new { acdac, at })
                                                                       .Where(acdacat => acdacat.at.AcademicTermId == _studentContext.Programs.Single(p => p.Code.Equals(_studentContext.Students.Include(s => s.Program).Single(s => s.StudentId == studentId).Program.Code)).AcademicTermId &&
                                                                              acdacat.acdac.ac.Name.Equals(courseArgs.AcademicTerm) &&
                                                                              acdacat.acdac.acd.AcademicCalendarDetailId >= _studentContext.Students.Include(s => s.AcademicCalendarDetail).Single(s => s.StudentId == studentId).AcademicCalendarDetail.AcademicCalendarDetailId &&
                                                                              acdacat.acdac.acd.Year == courseArgs.AcademicYear)
                                                                       .Select(acdacat => acdacat.acdac.acd.AcademicCalendarDetailId).SingleAsync();

            var courseDeleted = await _studentContext.EnrolledCourses.SingleAsync(ec => ec.CourseId == _studentContext.Courses.Single(c => c.Code.Equals(courseArgs.CourseCode) && c.Level == courseArgs.CourseLevel).CourseId && ec.StudentId == studentId &&
                                                                            ec.AcademicCalendarDetailId == academicCalendarDetailIdInWhichCourseWasOffered);

            if (courseDeleted != null)
            {
                _studentContext.EnrolledCourses.Remove(courseDeleted);
                await _studentContext.SaveChangesAsync();
            }

        }

        public async Task<List<YearAndTerm>> GetAademicYearsAndAcademicTermsACourseIsOffered(int studentId, int courseLevel, string courseCode)
        {
            var possibleYearsAndTermsACourseWasOffered = await _studentContext.AcademicCalendarDetails.Join(_studentContext.OfferedCourses, acd => acd.AcademicCalendarDetailId, oc => oc.AcademicCalendarDetailId, (acd, oc) => new { acd, oc })
                                                                                                .Join(_studentContext.AcademicCalendars, acdoc => acdoc.acd.AcademicCalendarId, ac => ac.AcademicCalendarId, (acdoc, ac) => new { acdoc, ac})
                                                                                                .Where(acdocac => acdocac.acdoc.oc.CourseId == _studentContext.Courses.Single(c => c.Code.Equals(courseCode) && c.Level.Equals(courseLevel)).CourseId &&
                                                                                                   acdocac.acdoc.acd.Year >= _studentContext.Students.Include(d => d.AcademicCalendarDetail).Single(s => s.StudentId == studentId).AcademicCalendarDetail.Year)
                                                                                                .ToListAsync();
            var yearsAndTerms = new List<YearAndTerm>();
            possibleYearsAndTermsACourseWasOffered.ForEach(acdocac =>
            {
                if (yearsAndTerms.Any(item => item.AcademicYear == acdocac.acdoc.acd.Year))
                {
                    yearsAndTerms.Single(item => item.AcademicYear == acdocac.acdoc.acd.Year).AcademicTerms.Add(acdocac.ac.Name);
                }
                else
                    yearsAndTerms.Add(new YearAndTerm { AcademicYear = acdocac.acdoc.acd.Year, AcademicTerms = new List<string> { acdocac.ac.Name } });
            }
            );
            return yearsAndTerms;
        }

        public async Task UpdatStudentEnrolledCourse(int studentId, CurrentAndNewCourseDetails courseArgs)
        {
            var currentAcademicCalendarDetailId = await _studentContext.AcademicCalendarDetails.Join(_studentContext.AcademicCalendars, acd => acd.AcademicCalendarId, ac => ac.AcademicCalendarId, (acd, ac) => new { acd, ac })
                                                        .Join(_studentContext.RefAcademicTerms, acdac => acdac.ac.AcademicTermId, at => at.AcademicTermId, (acdac, at) => new { acdac, at })
                                                            .Where(acdacat => acdacat.at.AcademicTermId == _studentContext.Programs.Single(p => p.Code.Equals(_studentContext.Students.Include(s => s.Program).Single(s => s.StudentId == studentId).Program.Code)).AcademicTermId &&
                                                                    acdacat.acdac.ac.Name.Equals(courseArgs.CurrentAcademicTerm) &&
                                                                    acdacat.acdac.acd.AcademicCalendarDetailId >= _studentContext.Students.Include(s => s.AcademicCalendarDetail).Single(s => s.StudentId == studentId).AcademicCalendarDetail.AcademicCalendarDetailId &&
                                                                    acdacat.acdac.acd.Year == courseArgs.CurrentAcademicYear)
                                                        .Select(acdacat => acdacat.acdac.acd.AcademicCalendarDetailId).SingleAsync();

            var course = await _studentContext.Courses.SingleAsync(c => c.Code == courseArgs.CourseCode);

            if (courseArgs.CurrentAcademicTerm != courseArgs.UpdatedAcademicTerm || courseArgs.CurrentAcademicYear != courseArgs.UpdatedAcademicYear)
            {
                var updatedAcademicCalendarDetailId = await _studentContext.AcademicCalendarDetails.Join(_studentContext.AcademicCalendars, acd => acd.AcademicCalendarId, ac => ac.AcademicCalendarId, (acd, ac) => new { acd, ac })
                                                        .Join(_studentContext.RefAcademicTerms, acdac => acdac.ac.AcademicTermId, at => at.AcademicTermId, (acdac, at) => new { acdac, at })
                                                            .Where(acdacat => acdacat.at.AcademicTermId == _studentContext.Programs.Single(p => p.Code.Equals(_studentContext.Students.Include(s => s.Program).Single(s => s.StudentId == studentId).Program.Code)).AcademicTermId &&
                                                                    acdacat.acdac.ac.Name.Equals(courseArgs.UpdatedAcademicTerm) &&
                                                                    acdacat.acdac.acd.AcademicCalendarDetailId >= _studentContext.Students.Include(s => s.AcademicCalendarDetail).Single(s => s.StudentId == studentId).AcademicCalendarDetail.AcademicCalendarDetailId &&
                                                                    acdacat.acdac.acd.Year == courseArgs.UpdatedAcademicYear)
                                                        .Select(acdacat => acdacat.acdac.acd.AcademicCalendarDetailId).SingleAsync();

                var studentCourseUpdate = await _studentContext.EnrolledCourses.SingleAsync(ec => ec.StudentId == studentId && ec.AcademicCalendarDetailId == currentAcademicCalendarDetailId && ec.CourseId == course.CourseId);
                _studentContext.Remove(studentCourseUpdate);
                await _studentContext.EnrolledCourses.AddAsync(new EnrolledCourse { StudentId = studentId, CourseId = course.CourseId, AcademicCalendarDetailId = updatedAcademicCalendarDetailId, Marks = courseArgs.UpdatedMarks });
                await _studentContext.SaveChangesAsync();
            }
            else
            {
                var studentMarksUpdate = await _studentContext.EnrolledCourses.SingleAsync(ec => ec.StudentId == studentId && ec.AcademicCalendarDetailId == currentAcademicCalendarDetailId && ec.CourseId == course.CourseId);
                studentMarksUpdate.Marks = courseArgs.UpdatedMarks;
                await _studentContext.SaveChangesAsync();
            }
        }
    }
}
