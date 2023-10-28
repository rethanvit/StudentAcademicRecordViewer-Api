using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SRV.Api.Models;
using SRV.DL;
using System.Linq;
using System.Linq.Expressions;

namespace SRV.Api.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _studentContext;

        public StudentRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<StudentDtoForGet> GetStudentByIdAsync(int studentId)
        {
            var studentInfo = await _studentContext.Students.Join(_studentContext.Programs, s => s.ProgramId, p => p.ProgramId, (s, p) => new { s, p })
                                                            .Join(_studentContext.Departments, sp => sp.p.DepartmentId, d => d.DepartmentId, (sp, d) => new { sp, d })
                                                            .Join(_studentContext.Organizations, spd => spd.d.OrganizationId, o => o.OrganizationId, (spd, o) => new { spd, o })
                                                            .Where(spdo => spdo.spd.sp.s.StudentId == studentId)
                                                            .Select(spdo => new StudentDtoForGet
                                                            {
                                                                StudentId = spdo.spd.sp.s.StudentId,
                                                                FirstName = spdo.spd.sp.s.FirstName,
                                                                LastName = spdo.spd.sp.s.LastName,
                                                                DepartmentId = spdo.spd.d.DepartmentId,
                                                                DepartmentName = spdo.spd.d.Name,
                                                                DepartmentCode = spdo.spd.d.Code,
                                                                ProgramId = spdo.spd.sp.p.ProgramId,
                                                                ProgramCode = spdo.spd.sp.p.Code,
                                                                ProgramName = spdo.spd.sp.p.Name,
                                                                OrganizationName = spdo.o.Name
                                                            }).SingleOrDefaultAsync();


            return studentInfo;
        }

        public async Task<StudentWithCoursesDtoGet> GetStudentAndEnrolledCoursesAsync(int studentId)
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
                studentWithCourseDetailsDto ??= new StudentWithCoursesDtoGet();
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
                                                                       .Where(acdacat => acdacat.at.AcademicTermId == _studentContext.Students.Include(s => s.Program).Single(s => s.StudentId == studentId).Program.AcademicTermId &&
                                                                              acdacat.acdac.ac.Name.Equals(courseArgs.AcademicTerm) &&
                                                                              acdacat.acdac.acd.AcademicCalendarDetailId >= _studentContext.Students.Single(s => s.StudentId == studentId).AcademicCalendarDetailStartId &&
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
            var possibleYearsAndTermsACourseWasOffered = await _studentContext.AcademicCalendarDetails
                                                                .Join(_studentContext.OfferedCourses, acd => acd.AcademicCalendarDetailId, oc => oc.AcademicCalendarDetailId, (acd, oc) => new { acd, oc })
                                                                .Join(_studentContext.AcademicCalendars, acdoc => acdoc.acd.AcademicCalendarId, ac => ac.AcademicCalendarId, (acdoc, ac) => new { acdoc, ac })
                                                                .Where(acdocac => acdocac.acdoc.oc.CourseId == _studentContext.Courses.Single(c => c.Code.Equals(courseCode) && c.Level.Equals(courseLevel)).CourseId &&
                                                                                  _studentContext.Courses.Single(c => c.CourseId == acdocac.acdoc.oc.CourseId).ProgramId == _studentContext.Students.Single(s => s.StudentId == studentId).ProgramId &&
                                                                                  acdocac.acdoc.acd.AcademicCalendarDetailId >= _studentContext.Students.Single(s => s.StudentId == studentId).AcademicCalendarDetailStartId)
                                                                .ToListAsync();
            var yearsAndTerms = new List<YearAndTerm>();
            possibleYearsAndTermsACourseWasOffered.ForEach(acdocac =>
            {
                if (yearsAndTerms.Any(item => item.AcademicYear == acdocac.acdoc.acd.Year))
                    yearsAndTerms.Single(item => item.AcademicYear == acdocac.acdoc.acd.Year).AcademicTerms.Add(acdocac.ac.Name);
                else
                    yearsAndTerms.Add(new YearAndTerm { AcademicYear = acdocac.acdoc.acd.Year, AcademicTerms = new List<string> { acdocac.ac.Name } });
            }
            );
            return yearsAndTerms;
        }

        public async Task UpdatStudentEnrolledCourse(int studentId, CurrentAndNewCourseDetails courseArgs)
        {
            var currentAcademicCalendarDetailId = await _studentContext.OfferedCourses
                                                        .Join(_studentContext.AcademicCalendarDetails, oc => oc.AcademicCalendarDetailId, acd => acd.AcademicCalendarDetailId, (oc, acd) => new { oc, acd })
                                                        .Join(_studentContext.AcademicCalendars, ocacd => ocacd.acd.AcademicCalendarId, ac => ac.AcademicCalendarId, (ocacd, ac) => new { ocacd, ac })
                                                        .Join(_studentContext.Courses, ocacdac => ocacdac.ocacd.oc.CourseId, c => c.CourseId, (ocacdac, c) => new { ocacdac, c })
                                                        .Where(ocacdacc => ocacdacc.c.ProgramId == _studentContext.Students.Include(s => s.Program).Single(s => s.StudentId == studentId).ProgramId &&
                                                                          ocacdacc.ocacdac.ac.Name.Equals(courseArgs.CurrentAcademicTerm) &&
                                                                          ocacdacc.ocacdac.ocacd.acd.AcademicCalendarDetailId >= _studentContext.Students.Single(s => s.StudentId == studentId).AcademicCalendarDetailStartId &&
                                                                          ocacdacc.ocacdac.ocacd.acd.Year == courseArgs.CurrentAcademicYear &&
                                                                          ocacdacc.c.Code.Equals(courseArgs.CourseCode) &&
                                                                          ocacdacc.c.Level == courseArgs.CourseLevel)
                                                        .Select(ocacdacc => ocacdacc.ocacdac.ocacd.acd.AcademicCalendarDetailId).SingleAsync();

            var course = await _studentContext.Courses.SingleAsync(c => c.Code == courseArgs.CourseCode && c.Level == courseArgs.CourseLevel);

            if (courseArgs.CurrentAcademicTerm != courseArgs.UpdatedAcademicTerm || courseArgs.CurrentAcademicYear != courseArgs.UpdatedAcademicYear)
            {
                var updatedAcademicCalendarDetailId = await _studentContext.OfferedCourses
                                                            .Join(_studentContext.AcademicCalendarDetails, oc => oc.AcademicCalendarDetailId, acd => acd.AcademicCalendarDetailId, (oc, acd) => new { oc, acd })
                                                            .Join(_studentContext.AcademicCalendars, ocacd => ocacd.acd.AcademicCalendarId, ac => ac.AcademicCalendarId, (ocacd, ac) => new { ocacd, ac })
                                                            .Join(_studentContext.Courses, ocacdac => ocacdac.ocacd.oc.CourseId, c => c.CourseId, (ocacdac, c) => new { ocacdac, c })
                                                            .Where(ocacdacc => ocacdacc.c.ProgramId == _studentContext.Students.Include(s => s.Program).Single(s => s.StudentId == studentId).ProgramId &&
                                                                              ocacdacc.ocacdac.ac.Name.Equals(courseArgs.UpdatedAcademicTerm) &&
                                                                              ocacdacc.ocacdac.ocacd.acd.AcademicCalendarDetailId >= _studentContext.Students.Single(s => s.StudentId == studentId).AcademicCalendarDetailStartId &&
                                                                              ocacdacc.ocacdac.ocacd.acd.Year == courseArgs.UpdatedAcademicYear &&
                                                                              ocacdacc.c.Code.Equals(courseArgs.CourseCode) &&
                                                                              ocacdacc.c.Level == courseArgs.CourseLevel)
                                                            .Select(ocacdacc => ocacdacc.ocacdac.ocacd.acd.AcademicCalendarDetailId).SingleAsync();

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

        public async Task<List<DepartmentDto>> GetDepartmentsbyOrganizationId(int organizationId)
        {
            return await _studentContext.Departments.Where(o => o.OrganizationId == organizationId).Select(d => new DepartmentDto
            {
                DepartmentId = d.DepartmentId,
                Code = d.Code,
                Name = d.Name,
                StartDate = d.StartDate,
                StopDate = d.StopDate,
            }).ToListAsync();
        }

        public async Task<List<OrganizationDto>> GetOrganizations()
        {
            return await _studentContext.Organizations.Select(o => new OrganizationDto
            {
                OrganizationId = o.OrganizationId,
                Name = o.Name,
                Active = o.Active,
                StartDate = o.StartDate,
                StopDate = o.StopDate
            }).ToListAsync();
        }

        public async Task<List<ProgramDto>> GetProgramsByDepartmentId(int departmentId)
        {
            return await _studentContext.Programs.Where(d => d.DepartmentId == departmentId).Select(p => new ProgramDto
            {
                ProgramId = p.ProgramId,
                Name = p.Name,
                Code = p.Code
            }).ToListAsync();
        }

        public async Task<List<AcademicCalendarDetailOptionsDto>> GetAcademicCalendarDetailsByAcademicTermId(int programId)
        {
            return await _studentContext.Programs.Join(_studentContext.AcademicCalendars, p => p.AcademicTermId, ac => ac.AcademicTermId, (p, ac) => new { p, ac })
                                                 .Join(_studentContext.AcademicCalendarDetails, pac => pac.ac.AcademicCalendarId, acd => acd.AcademicCalendarId, (pacac, acd) => new { pacac, acd })
                                                 .Where(pacacacd => pacacacd.pacac.p.ProgramId == programId)
                                                 .Select(pacacacd => new AcademicCalendarDetailOptionsDto
                                                 {
                                                     AcademicCalendarDetailId = pacacacd.acd.AcademicCalendarDetailId,
                                                     Year = pacacacd.acd.Year,
                                                     StartDate = pacacacd.acd.StartDate,
                                                     Term = pacacacd.pacac.ac.Name
                                                 }).OrderBy(acdo => acdo.AcademicCalendarDetailId)
                                                 .ToListAsync();
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> queryPredicate) where T : class
        {
            return _studentContext.Set<T>().Where(queryPredicate);
        }

        public async Task<int> AddStudent(AddStudentDto addStudentDto)
        {
            var studentToBeAdded = new Student
            {
                ProgramId = addStudentDto.ProgramId,
                FirstName = addStudentDto.FirstName,
                LastName = addStudentDto.LastName,
                AcademicCalendarDetailStartId = addStudentDto.AcademicDetailsStartId,
                StartDate = _studentContext.AcademicCalendarDetails.Single(acds => acds.AcademicCalendarDetailId == addStudentDto.AcademicDetailsStartId).StartDate,
                StopDate = new DateTime(2079, 06, 06)
            };
            _studentContext.Add(studentToBeAdded);

            await _studentContext.SaveChangesAsync();

            return studentToBeAdded.StudentId;
        }

        public async Task<List<CourseDto>> GetCoursesThatTheStudentCouldHaveEnrolled(int studentId)
        {
            //DO NOT JOIN Program table on AcademicTermId with AcademicTermId from AcademicCalendar table. It will be an issue when you have multiple programs with same AcademicTermId. Fix it.
            //The unit test with comment //AcademicTermId will fail with previous version of the below query. It works fine in other queries, so DOUBLE check other queries with join on AcademicTermId
            var coursesThatStudentCouldHaveEnrolledFor = await _studentContext.OfferedCourses.Join(_studentContext.Courses, oc => oc.CourseId, c => c.CourseId, (oc, c) => new { oc, c })
                                             .Join(_studentContext.AcademicCalendarDetails, occ => occ.oc.AcademicCalendarDetailId, acd => acd.AcademicCalendarDetailId, (occ, acd) => new { occ, acd })
                                             .Join(_studentContext.AcademicCalendars, occacd => occacd.acd.AcademicCalendarId, ac => ac.AcademicCalendarId, (occacd, ac) => new { occacd, ac })
                                             .Where(occacdac => occacdac.occacd.occ.c.ProgramId == _studentContext.Students.Single(s => s.StudentId == studentId).ProgramId &&
                                                    occacdac.occacd.acd.AcademicCalendarDetailId >= _studentContext.Students.Single(s => s.StudentId == studentId).AcademicCalendarDetailStartId &&
                                                    !_studentContext.EnrolledCourses.Where(s => s.StudentId == studentId).Select(cid => cid.CourseId).ToList().Contains(occacdac.occacd.occ.oc.CourseId))
                                             .Select(occacdac => new
                                             {
                                                 CourseId = occacdac.occacd.occ.c.CourseId,
                                                 Code = occacdac.occacd.occ.c.Code,
                                                 Level = occacdac.occacd.occ.c.Level,
                                                 Name = occacdac.occacd.occ.c.Name,
                                                 Term = occacdac.ac.Name,
                                                 Year = occacdac.occacd.acd.Year
                                             })
                                             .ToListAsync();

            var listOfCoursesAndTerms = new List<CourseDto>();
            foreach (var course in coursesThatStudentCouldHaveEnrolledFor)
            {
                if (!listOfCoursesAndTerms.Any(item => item.CourseId == course.CourseId))
                {
                    listOfCoursesAndTerms.Add(new CourseDto { CourseId = course.CourseId, Code = course.Code, Level = course.Level, Name = course.Name, YearAndTerms = new List<YearAndTerm>() });
                }

                if (listOfCoursesAndTerms.Any(item => item.CourseId == course.CourseId && !item.YearAndTerms.Any(yat => yat.AcademicYear == course.Year)))
                {
                    listOfCoursesAndTerms.Single(item => item.CourseId == course.CourseId).YearAndTerms.Add(new YearAndTerm { AcademicYear = course.Year, AcademicTerms = new List<string>() });
                }

                if (listOfCoursesAndTerms.Any(item => item.CourseId == course.CourseId && item.YearAndTerms.Any(yat => yat.AcademicYear == course.Year)))
                {
                    listOfCoursesAndTerms.Single(item => item.CourseId == course.CourseId).YearAndTerms.Single(yat => yat.AcademicYear == course.Year).AcademicTerms.Add(course.Term);
                }
            }

            return listOfCoursesAndTerms;
        }

        public async Task<int> AddStudentCourse(int studentId, AddEnrolledCourseRequestDto addEnrolledCourseRequestDto)
        {
            //DO NOT JOIN Program table on AcademicTermId. It will be an issue when you have multiple programs with same AcademicTermId. Fix it.
            //The unit test with comment //AcademicTermId will fail with previous version of the below query. DOUBLE check other queries with join on AcademicTermId
            var academicCalendarDetailId = await _studentContext.OfferedCourses.Join(_studentContext.AcademicCalendarDetails, oc => oc.AcademicCalendarDetailId, acd => acd.AcademicCalendarDetailId, (oc, acd) => new { oc, acd })
                                                 .Join(_studentContext.AcademicCalendars, ocacd => ocacd.acd.AcademicCalendarId, ac => ac.AcademicCalendarId, (ocacd, ac) => new { ocacd, ac })
                                                 .Where(ocacdac => ocacdac.ocacd.acd.AcademicCalendarDetailId >= _studentContext.Students.Single(s => s.StudentId == studentId).AcademicCalendarDetailStartId &&
                                                        _studentContext.Students.Single(s => s.StudentId == studentId).ProgramId == ocacdac.ocacd.oc.Course.ProgramId
                                                        && ocacdac.ocacd.acd.Year == addEnrolledCourseRequestDto.year
                                                        && ocacdac.ocacd.oc.CourseId == addEnrolledCourseRequestDto.courseId
                                                        && ocacdac.ac.Name.Equals(addEnrolledCourseRequestDto.term)).Select(ocacdac => ocacdac.ocacd.acd.AcademicCalendarDetailId).SingleAsync();



            _studentContext.Add(new EnrolledCourse
            {
                AcademicCalendarDetailId = academicCalendarDetailId,
                CourseId = addEnrolledCourseRequestDto.courseId,
                Marks = addEnrolledCourseRequestDto.marks,
                StudentId = studentId
            });

            return await _studentContext.SaveChangesAsync();
        }
    }
}
