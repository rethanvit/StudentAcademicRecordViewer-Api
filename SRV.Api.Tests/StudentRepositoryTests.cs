using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SRV.Api.Models;
using SRV.Api.Services;
using SRV.DL;

namespace SRV.Api.Tests
{
    [TestClass]
    public class StudentRepositoryTests
    {
        [TestMethod]
        public async Task GetStudentByIdAsync_ReturnsRequiredStudentInfo_WhenProvidedAValidAndExistingStudentId()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetStudentByIdAsync1");
            var studentContext = new StudentContext(builder.Options);

            var programs = new List<Program> {
                new Program {
                    ProgramId = 1,
                    Code = "Prog1",
                    Name = "TestProg1Name",
                    AcademicTermId = 1,
                    Active = true,
                    DepartmentId = 1,
                },
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var departments = new List<Department> {
                new Department{
                    DepartmentId=1,
                    Code="DEP1",
                    Active=true,
                    Name= "DEPName1",
                    OrganizationId=1,
                },
                new Department{
                    DepartmentId=2,
                    Code="DEP2",
                    Active=true,
                    Name= "DEPName2",
                    OrganizationId=1,
                }
            };
            var organizations = new List<Organization> {
                new Organization{
                    Active=true,
                    Name= "OrgName1",
                    OrganizationId=1,
                },
                new Organization{
                    Active=true,
                    Name= "OrgName2",
                    OrganizationId=2,
                },
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=1,
                    AcademicCalendarDetailStartId = 8,
                }
            };

            studentContext.AddRange(organizations);
            studentContext.AddRange(departments);
            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var result = await studentRepository.GetStudentByIdAsync(234);

            //Assert
            var expectedStudentInfo = new StudentDtoForGet
            {
                DepartmentCode = "DEP1",
                DepartmentId = 1,
                DepartmentName = "DEPName1",
                FirstName = "TestFName1",
                LastName = "TestLName1",
                OrganizationName = "OrgName1",
                ProgramCode = "Prog1",
                ProgramId = 1,
                ProgramName = "TestProg1Name",
                StudentId = 234
            };

            result.Should().BeEquivalentTo(expectedStudentInfo);
        }

        [TestMethod]
        public async Task GetStudentByIdAsync_ReturnsNull_WhenProvidedANotExistingStudentId()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetStudentByIdAsync2");
            var studentContext = new StudentContext(builder.Options);

            var programs = new List<Program> {
                new Program {
                    ProgramId = 1,
                    Code = "Prog1",
                    Name = "TestProg1Name",
                    AcademicTermId = 1,
                    Active = true,
                    DepartmentId = 1,
                },
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var departments = new List<Department> {
                new Department{
                    DepartmentId=1,
                    Code="DEP1",
                    Active=true,
                    Name= "DEPName1",
                    OrganizationId=1,
                },
                new Department{
                    DepartmentId=2,
                    Code="DEP2",
                    Active=true,
                    Name= "DEPName2",
                    OrganizationId=1,
                }
            };
            var organizations = new List<Organization> {
                new Organization{
                    Active=true,
                    Name= "OrgName1",
                    OrganizationId=1,
                },
                new Organization{
                    Active=true,
                    Name= "OrgName2",
                    OrganizationId=2,
                },
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=1,
                    AcademicCalendarDetailStartId = 8,
                }
            };

            studentContext.AddRange(organizations);
            studentContext.AddRange(departments);
            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var result = await studentRepository.GetStudentByIdAsync(345);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public async Task GetStudentAndEnrolledCourseAsync_ReturnsCoursesEnrolled_WhenProvidedExistingStudentId()
        {
            //Arrange
            var programs = new List<Program> {
                new Program {
                    ProgramId = 1,
                    Code = "Prog1",
                    Name = "TestProg1Name",
                    AcademicTermId = 1,
                    Active = true,
                    DepartmentId = 1,
                },
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var departments = new List<Department> {
                new Department{
                    DepartmentId=1,
                    Code="DEP1",
                    Active=true,
                    Name= "DEPName1",
                    OrganizationId=1,
                },
                new Department{
                    DepartmentId=2,
                    Code="DEP2",
                    Active=true,
                    Name= "DEPName2",
                    OrganizationId=1,
                }
            };
            var organizations = new List<Organization> {
                new Organization{
                    Active=true,
                    Name= "OrgName1",
                    OrganizationId=1,
                },
                new Organization{
                    Active=true,
                    Name= "OrgName2",
                    OrganizationId=2,
                },
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=1,
                    AcademicCalendarDetailStartId = 1,
                }
            };
            var enrolledCourses = new List<EnrolledCourse> {
                new EnrolledCourse {
                    AcademicCalendarDetailId=2,
                    CourseId=2,
                    Marks = 55,
                    StudentId=234
                },
                new EnrolledCourse {
                    AcademicCalendarDetailId=3,
                    CourseId =3,
                    Marks = 60,
                    StudentId=234
                }
            };
            var courses = new List<Course> {
                new Course {
                    CourseId = 2,
                    Code = "C2",
                    Name = "C2Name",
                    Level = 101,
                    ProgramId = 1
                },
                new Course {
                    CourseId = 3,
                    Code = "C3",
                    Name = "C3Name",
                    Level = 101,
                    ProgramId = 1
                },
            };
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                }
            };

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetStudentAndEnrolledCourseAsync1");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(organizations);
            studentContext.AddRange(departments);
            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.AddRange(enrolledCourses);
            studentContext.AddRange(courses);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);

            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var result = await studentRepository.GetStudentAndEnrolledCoursesAsync(234);

            //Assert
            var expectedResult = new StudentWithCoursesDtoGet
            {
                StudentId = 234,
                FirstName = "TestFName1",
                LastName = "TestLName1",
                CoursesEnrolled = new List<EnrolledCourseDetailsDto>
                    {
                        new EnrolledCourseDetailsDto {
                            CourseLevel = 101,
                            AcademicTerm = "Spring",
                            AcademicYear = 2020,
                            CourseCode = "C2",
                            CourseName = "C2Name",
                            DepartmentName = "DEPName1",
                            Marks = 55
                        },
                        new EnrolledCourseDetailsDto {
                            CourseLevel = 101,
                            AcademicTerm = "Fall",
                            AcademicYear = 2020,
                            CourseCode = "C3",
                            CourseName = "C3Name",
                            DepartmentName = "DEPName1",
                            Marks = 60
                        }
                    }
            };

            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public async Task GetStudentAndEnrolledCourseAsync_ReturnsNoCoursesEnrolled_WhenProvidedExistingStudentIdWhoDidNotEnrollAnyCourses()
        {
            //Arrange
            var programs = new List<Program> {
                new Program {
                    ProgramId = 1,
                    Code = "Prog1",
                    Name = "TestProg1Name",
                    AcademicTermId = 1,
                    Active = true,
                    DepartmentId = 1,
                },
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var departments = new List<Department> {
                new Department{
                    DepartmentId=1,
                    Code="DEP1",
                    Active=true,
                    Name= "DEPName1",
                    OrganizationId=1,
                },
                new Department{
                    DepartmentId=2,
                    Code="DEP2",
                    Active=true,
                    Name= "DEPName2",
                    OrganizationId=1,
                }
            };
            var organizations = new List<Organization> {
                new Organization{
                    Active=true,
                    Name= "OrgName1",
                    OrganizationId=1,
                },
                new Organization{
                    Active=true,
                    Name= "OrgName2",
                    OrganizationId=2,
                },
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=1,
                    AcademicCalendarDetailStartId = 1,
                }
            };
            var enrolledCourses = new List<EnrolledCourse> {};
            var courses = new List<Course> {
                new Course {
                    CourseId = 2,
                    Code = "C2",
                    Name = "C2Name",
                    Level = 101,
                    ProgramId = 1
                },
                new Course {
                    CourseId = 3,
                    Code = "C3",
                    Name = "C3Name",
                    Level = 101,
                    ProgramId = 1
                },
            };
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                }
            };

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetStudentAndEnrolledCourseAsync2");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(organizations);
            studentContext.AddRange(departments);
            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.AddRange(enrolledCourses);
            studentContext.AddRange(courses);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);

            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var result = await studentRepository.GetStudentAndEnrolledCoursesAsync(234);

            //Assert
            var expectedResult = new StudentWithCoursesDtoGet
            {
                StudentId = 234,
                FirstName = "TestFName1",
                LastName = "TestLName1",
                CoursesEnrolled = new List<EnrolledCourseDetailsDto>{}
            };

            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public async Task DeleteCoursesEnrolled_DeletesTheCourse_WhenPassedValidCourseDetailsOfTheStudent()
        {
            //Arrange
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                }
            };
            var academicTerms = new List<RefAcademicTerm> {
                new RefAcademicTerm{ 
                    AcademicTermId = 2,
                    Name="Bi-Semester",
                    Terms = 2
                }
            };
            var programs = new List<Program> {
                new Program {
                    ProgramId = 1,
                    Code = "Prog1",
                    Name = "TestProg1Name",
                    AcademicTermId = 1,
                    Active = true,
                    DepartmentId = 1,
                },
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=2,
                    AcademicCalendarDetailStartId = 2,
                }
            };
            var enrolledCourses = new List<EnrolledCourse> {
                new EnrolledCourse {
                    AcademicCalendarDetailId=2,
                    CourseId=2,
                    Marks = 55,
                    StudentId=234
                },
                new EnrolledCourse {
                    AcademicCalendarDetailId=3,
                    CourseId =3,
                    Marks = 60,
                    StudentId=234
                }
            };
            var courses = new List<Course> {
                new Course {
                    CourseId = 2,
                    Code = "C2",
                    Name = "C2Name",
                    Level = 101,
                    ProgramId = 1
                },
                new Course {
                    CourseId = 3,
                    Code = "C3",
                    Name = "C3Name",
                    Level = 101,
                    ProgramId = 2
                },
            };

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("DeleteCoursesEnrolled1");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.AddRange(enrolledCourses);
            studentContext.AddRange(courses);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);
            studentContext.AddRange(academicTerms);

            studentContext.SaveChanges();

            var studentRepository = new StudentRepository(studentContext);
            var courseToBeDeleted = new CourseArgs { 
                CourseCode = "C3",
                CourseLevel = 101,
                AcademicTerm = "Fall",
                AcademicYear = 2020
            };

            //Act
            await studentRepository.DeleteCoursesEnrolled(234, courseToBeDeleted);

            //Assert
            studentContext.EnrolledCourses.SingleOrDefault(ec => ec.CourseId == 3).Should().BeNull();
            studentContext.EnrolledCourses.SingleOrDefault(ec => ec.CourseId == 2).Should().NotBeNull();

        }

        [TestMethod]
        public async Task TriSemester_GetAademicYearsAndAcademicTermsACourseIsOffered_ReturnsYearAndTermsTheCourseWasOfferedToStudent_WhenProvidedCourseDetails()
        {
            //Arrange
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 4,
                    AcademicCalendarId=4,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,05,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 5,
                    AcademicCalendarId=5,
                    Year = 2020,
                    StartDate= new DateTime(2020,06,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 6,
                    AcademicCalendarId=6,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                },
                new AcademicCalendar {
                    AcademicCalendarId=4,
                    AcademicTermId=3,
                    Name="Spring",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=5,
                    AcademicTermId=3,
                    Name="Summer",
                }
            };
            var programs = new List<Program> {
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 3,
                    Code = "Prog3",
                    Name = "TestProg3Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var courses = new List<Course> {
                new Course {
                    CourseId = 2,
                    Code = "C2",
                    Name = "C2Name",
                    Level = 101,
                    ProgramId = 2
                },
                new Course {
                    CourseId = 3,
                    Code = "C3",
                    Name = "C3Name",
                    Level = 101,
                    ProgramId = 3
                },
            };
            var offeredCourses = new List<OfferedCourse>
            {
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 2},
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 3},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 4},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 5},
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=3,
                    AcademicCalendarDetailStartId = 2,
                }
            };


            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetAademicYearsAndAcademicTermsACourseIsOffered1");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.AddRange(courses);
            studentContext.AddRange(offeredCourses);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);

            studentContext.SaveChanges();
            
            //Act
            var studentRepository = new StudentRepository(studentContext);
            var result = await studentRepository.GetAademicYearsAndAcademicTermsACourseIsOffered(234, 101, "C3");

            //Assert
            var expectedResult = new List<YearAndTerm> { 
                new YearAndTerm{ 
                    AcademicYear = 2020,
                    AcademicTerms = new List<string> {"Spring", "Summer"}
                }
            };

            result.Should().BeEquivalentTo(expectedResult);

        }

        [TestMethod]
        public async Task BiSemester_GetAademicYearsAndAcademicTermsACourseIsOffered_ReturnsYearAndTermsTheCourseWasOfferedToStudent_WhenProvidedCourseDetails()
        {
            //Arrange
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 4,
                    AcademicCalendarId=4,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,05,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 5,
                    AcademicCalendarId=5,
                    Year = 2020,
                    StartDate= new DateTime(2020,06,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 6,
                    AcademicCalendarId=6,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                },
                new AcademicCalendar {
                    AcademicCalendarId=4,
                    AcademicTermId=3,
                    Name="Spring",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=5,
                    AcademicTermId=3,
                    Name="Summer",
                }
            };
            var programs = new List<Program> {
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 3,
                    Code = "Prog3",
                    Name = "TestProg3Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var courses = new List<Course> {
                new Course {
                    CourseId = 2,
                    Code = "C2",
                    Name = "C2Name",
                    Level = 101,
                    ProgramId = 2
                },
                new Course {
                    CourseId = 3,
                    Code = "C3",
                    Name = "C3Name",
                    Level = 101,
                    ProgramId = 3
                },
            };
            var offeredCourses = new List<OfferedCourse>
            {
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 2},
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 3},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 4},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 5},
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=2,
                    AcademicCalendarDetailStartId = 2,
                }
            };


            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetAademicYearsAndAcademicTermsACourseIsOffered2");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.AddRange(courses);
            studentContext.AddRange(offeredCourses);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);

            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var result = await studentRepository.GetAademicYearsAndAcademicTermsACourseIsOffered(234, 101, "C2");

            //Assert
            var expectedResult = new List<YearAndTerm> {
                new YearAndTerm{
                    AcademicYear = 2020,
                    AcademicTerms = new List<string> {"Spring", "Fall"}
                }
            };

            result.Should().BeEquivalentTo(expectedResult);

        }

        [TestMethod]
        public async Task UpdatStudentEnrolledCourse_UpdatesOnlyMarks_WhenTheCourseAcademicTermAndTermDidntChange()
        {
            //Arrange
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                },
                new AcademicCalendar {
                    AcademicCalendarId=4,
                    AcademicTermId=3,
                    Name="Spring",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=5,
                    AcademicTermId=3,
                    Name="Summer",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=6,
                    AcademicTermId=3,
                    Name="Fall",
                }
            };
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 4,
                    AcademicCalendarId=4,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,05,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 5,
                    AcademicCalendarId=5,
                    Year = 2020,
                    StartDate= new DateTime(2020,06,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 6,
                    AcademicCalendarId=6,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var offeredCourses = new List<OfferedCourse>
            {
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 2},
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 3},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 4},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 5},
            };
            var courses = new List<Course> {
                new Course {
                    CourseId = 2,
                    Code = "C2",
                    Name = "C2Name",
                    Level = 101,
                    ProgramId = 2
                },
                new Course {
                    CourseId = 3,
                    Code = "C3",
                    Name = "C3Name",
                    Level = 101,
                    ProgramId = 3
                },
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=3,
                    AcademicCalendarDetailStartId = 2,
                }
            };
            var programs = new List<Program> {
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 3,
                    Code = "Prog3",
                    Name = "TestProg3Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var enrolledCourses = new List<EnrolledCourse> {
                new EnrolledCourse {
                    AcademicCalendarDetailId=2,
                    CourseId=2,
                    Marks = 55,
                    StudentId=234
                },
                new EnrolledCourse {
                    AcademicCalendarDetailId=4,
                    CourseId =3,
                    Marks = 60,
                    StudentId=234
                }
            };


            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("UpdatStudentEnrolledCourse1");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.AddRange(courses);
            studentContext.AddRange(offeredCourses);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);
            studentContext.AddRange(enrolledCourses);

            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            await studentRepository.UpdatStudentEnrolledCourse(234, new CurrentAndNewCourseDetails {
                CourseCode = "C3",
                CourseLevel = 101,
                CurrentAcademicTerm = "Spring",
                CurrentAcademicYear = 2020,
                CurrentMarks = 60,
                UpdatedAcademicTerm = "Spring",
                UpdatedAcademicYear = 2020,
                UpdatedMarks = 70
            });

            //Assert
            var expected = new EnrolledCourse {
                Marks = 70,
                AcademicCalendarDetailId = 4,
                CourseId = 3,
                StudentId = 234,
            };
            studentContext.EnrolledCourses.Single(ec => ec.CourseId == 3 && ec.StudentId == 234).Marks.Should().Be(expected.Marks);
            studentContext.EnrolledCourses.Single(ec => ec.CourseId == 3 && ec.StudentId == 234).AcademicCalendarDetailId.Should().Be(expected.AcademicCalendarDetailId);

            //Negitive test
            studentContext.EnrolledCourses.Single(ec => ec.CourseId == 2 && ec.StudentId == 234).Marks.Should().Be(55);
            studentContext.EnrolledCourses.Single(ec => ec.CourseId == 2 && ec.StudentId == 234).AcademicCalendarDetailId.Should().Be(2);
        }

        [TestMethod]
        public async Task UpdatStudentEnrolledCourse_UpdatesMarksAndAcademicTermDetailId_WhenTheCourseAcademicTermAndTermAreUpdated()
        {
            //Arrange
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                },
                new AcademicCalendar {
                    AcademicCalendarId=4,
                    AcademicTermId=3,
                    Name="Spring",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=5,
                    AcademicTermId=3,
                    Name="Summer",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=6,
                    AcademicTermId=3,
                    Name="Fall",
                }
            };
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 4,
                    AcademicCalendarId=4,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,05,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 5,
                    AcademicCalendarId=5,
                    Year = 2020,
                    StartDate= new DateTime(2020,06,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 6,
                    AcademicCalendarId=6,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var offeredCourses = new List<OfferedCourse>
            {
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 2},
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 3},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 4},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 5},
            };
            var courses = new List<Course> {
                new Course {
                    CourseId = 2,
                    Code = "C2",
                    Name = "C2Name",
                    Level = 101,
                    ProgramId = 2
                },
                new Course {
                    CourseId = 3,
                    Code = "C3",
                    Name = "C3Name",
                    Level = 101,
                    ProgramId = 3
                },
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=3,
                    AcademicCalendarDetailStartId = 2,
                }
            };
            var programs = new List<Program> {
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 3,
                    Code = "Prog3",
                    Name = "TestProg3Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var enrolledCourses = new List<EnrolledCourse> {
                new EnrolledCourse {
                    AcademicCalendarDetailId=2,
                    CourseId=2,
                    Marks = 55,
                    StudentId=234
                },
                new EnrolledCourse {
                    AcademicCalendarDetailId=4,
                    CourseId =3,
                    Marks = 60,
                    StudentId=234
                }
            };


            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("UpdatStudentEnrolledCourse2");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.AddRange(courses);
            studentContext.AddRange(offeredCourses);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);
            studentContext.AddRange(enrolledCourses);

            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            await studentRepository.UpdatStudentEnrolledCourse(234, new CurrentAndNewCourseDetails
            {
                CourseCode = "C3",
                CourseLevel = 101,
                CurrentAcademicTerm = "Spring",
                CurrentAcademicYear = 2020,
                CurrentMarks = 60,
                UpdatedAcademicTerm = "Summer",
                UpdatedAcademicYear = 2020,
                UpdatedMarks = 70
            });

            //Assert
            var expected = new EnrolledCourse
            {
                Marks = 70,
                AcademicCalendarDetailId = 5,
                CourseId = 3,
                StudentId = 234,
            };
            studentContext.EnrolledCourses.Single(ec => ec.CourseId == 3 && ec.StudentId == 234).Marks.Should().Be(expected.Marks);
            studentContext.EnrolledCourses.Single(ec => ec.CourseId == 3 && ec.StudentId == 234).AcademicCalendarDetailId.Should().Be(expected.AcademicCalendarDetailId);

            //Negitive test
            studentContext.EnrolledCourses.Single(ec => ec.CourseId == 2 && ec.StudentId == 234).Marks.Should().Be(55);
            studentContext.EnrolledCourses.Single(ec => ec.CourseId == 2 && ec.StudentId == 234).AcademicCalendarDetailId.Should().Be(2);
        }

        [TestMethod]
        public async Task GetCoursesThatTheStudentCouldHaveEnrolled_ReturnsCourseDetailsWithYearAndTerms_WhenProvidedStudentId()
        {
            var offeredCourses = new List<OfferedCourse>
            {
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 2},
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 3},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 4},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 5},
            };
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                },
                new AcademicCalendar {
                    AcademicCalendarId=4,
                    AcademicTermId=3,
                    Name="Spring",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=5,
                    AcademicTermId=3,
                    Name="Summer",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=6,
                    AcademicTermId=3,
                    Name="Fall",
                }
            };
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 4,
                    AcademicCalendarId=4,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,05,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 5,
                    AcademicCalendarId=5,
                    Year = 2020,
                    StartDate= new DateTime(2020,06,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 6,
                    AcademicCalendarId=6,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var courses = new List<Course> {
                new Course {
                    CourseId = 2,
                    Code = "C2",
                    Name = "C2Name",
                    Level = 101,
                    ProgramId = 2
                },
                new Course {
                    CourseId = 3,
                    Code = "C3",
                    Name = "C3Name",
                    Level = 101,
                    ProgramId = 3
                },
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=3,
                    AcademicCalendarDetailStartId = 4,
                }
            };
            var programs = new List<Program> {
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 3,
                    Code = "Prog3",
                    Name = "TestProg3Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var academicTerms = new List<RefAcademicTerm> { 
                new RefAcademicTerm{
                    AcademicTermId= 2,
                    Name = "Bi-Semester",
                    Terms = 2
                },
                new RefAcademicTerm{
                    AcademicTermId= 3,
                    Name = "tri-Semester",
                    Terms = 3
                }
            };
            var enrolledCourses = new List<EnrolledCourse> {};

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetCoursesThatTheStudentCouldHaveEnrolled1");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.AddRange(courses);
            studentContext.AddRange(offeredCourses);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);
            studentContext.AddRange(enrolledCourses);
            studentContext.AddRange(academicTerms);

            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var actualCourseOptions = await studentRepository.GetCoursesThatTheStudentCouldHaveEnrolled(234);

            //Assert
            var expected = new List<CourseDto> { 
                new CourseDto { 
                    CourseId = 3,
                    Code="C3",
                    Name="C3Name",
                    Level=101,
                    YearAndTerms = new List<YearAndTerm>{ 
                        new YearAndTerm { 
                            AcademicYear = 2020,
                            AcademicTerms = new List<string> { "Spring", "Summer"}
                        }
                    }
                }
            };
            actualCourseOptions.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task GetCoursesThatTheStudentCouldHaveEnrolled_ReturnsCourseDetailsWithYearAndOnlyTermsOnOrAfterTheStudentStart_WhenCourseWasOfferedEvenBeforeTheStudentStarted()
        {
            var offeredCourses = new List<OfferedCourse>
            {
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 2},
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 3},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 4},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 5},
            };
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                },
                new AcademicCalendar {
                    AcademicCalendarId=4,
                    AcademicTermId=3,
                    Name="Spring",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=5,
                    AcademicTermId=3,
                    Name="Summer",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=6,
                    AcademicTermId=3,
                    Name="Fall",
                }
            };
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 4,
                    AcademicCalendarId=4,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,05,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 5,
                    AcademicCalendarId=5,
                    Year = 2020,
                    StartDate= new DateTime(2020,06,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 6,
                    AcademicCalendarId=6,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var courses = new List<Course> {
                new Course {
                    CourseId = 2,
                    Code = "C2",
                    Name = "C2Name",
                    Level = 101,
                    ProgramId = 2
                },
                new Course {
                    CourseId = 3,
                    Code = "C3",
                    Name = "C3Name",
                    Level = 101,
                    ProgramId = 3
                },
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=3,
                    AcademicCalendarDetailStartId = 5,
                }
            };
            var programs = new List<Program> {
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 3,
                    Code = "Prog3",
                    Name = "TestProg3Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var academicTerms = new List<RefAcademicTerm> {
                new RefAcademicTerm{
                    AcademicTermId= 2,
                    Name = "Bi-Semester",
                    Terms = 2
                },
                new RefAcademicTerm{
                    AcademicTermId= 3,
                    Name = "tri-Semester",
                    Terms = 3
                }
            };
            var enrolledCourses = new List<EnrolledCourse> { };

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetCoursesThatTheStudentCouldHaveEnrolled2");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.AddRange(courses);
            studentContext.AddRange(offeredCourses);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);
            studentContext.AddRange(enrolledCourses);
            studentContext.AddRange(academicTerms);

            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var actualCourseOptions = await studentRepository.GetCoursesThatTheStudentCouldHaveEnrolled(234);

            //Assert
            var expected = new List<CourseDto> {
                new CourseDto {
                    CourseId = 3,
                    Code="C3",
                    Name="C3Name",
                    Level=101,
                    YearAndTerms = new List<YearAndTerm>{
                        new YearAndTerm {
                            AcademicYear = 2020,
                            AcademicTerms = new List<string> {"Summer"}
                        }
                    }
                }
            };
            actualCourseOptions.Should().BeEquivalentTo(expected);
        }

        //AcademicTermId
        [TestMethod]
        public async Task GetCoursesThatTheStudentCouldHaveEnrolled_ReturnsCourseDetailsWithYearAndOnlyTermsOnlyFromTheProgramStudentBelongsTo_WhenStudentIdWasProvided()
        {
            var offeredCourses = new List<OfferedCourse>
            {
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 2},
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 3},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 4},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 5},
                new OfferedCourse {CourseId = 4, AcademicCalendarDetailId = 5},
                new OfferedCourse {CourseId = 4, AcademicCalendarDetailId = 6},
            };
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                },
                new AcademicCalendar {
                    AcademicCalendarId=4,
                    AcademicTermId=3,
                    Name="Spring",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=5,
                    AcademicTermId=3,
                    Name="Summer",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=6,
                    AcademicTermId=3,
                    Name="Fall",
                }
            };
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 4,
                    AcademicCalendarId=4,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,05,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 5,
                    AcademicCalendarId=5,
                    Year = 2020,
                    StartDate= new DateTime(2020,06,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 6,
                    AcademicCalendarId=6,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var courses = new List<Course> {
                new Course {
                    CourseId = 2,
                    Code = "C2",
                    Name = "C2Name",
                    Level = 101,
                    ProgramId = 2
                },
                new Course {
                    CourseId = 3,
                    Code = "C3",
                    Name = "C3Name",
                    Level = 101,
                    ProgramId = 3
                },
                new Course {
                    CourseId = 4,
                    Code = "C4",
                    Name = "C4Name",
                    Level = 101,
                    ProgramId = 4
                },
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=3,
                    AcademicCalendarDetailStartId = 4,
                }
            };
            var programs = new List<Program> {
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 3,
                    Code = "Prog3",
                    Name = "TestProg3Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 4,
                    Code = "Prog4",
                    Name = "TestProg4Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var academicTerms = new List<RefAcademicTerm> {
                new RefAcademicTerm{
                    AcademicTermId= 2,
                    Name = "Bi-Semester",
                    Terms = 2
                },
                new RefAcademicTerm{
                    AcademicTermId= 3,
                    Name = "tri-Semester",
                    Terms = 3
                }
            };
            var enrolledCourses = new List<EnrolledCourse> { };

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetCoursesThatTheStudentCouldHaveEnrolled3");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.AddRange(courses);
            studentContext.AddRange(offeredCourses);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);
            studentContext.AddRange(enrolledCourses);
            studentContext.AddRange(academicTerms);

            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var actualCourseOptions = await studentRepository.GetCoursesThatTheStudentCouldHaveEnrolled(234);

            //Assert
            var expected = new List<CourseDto> {
                new CourseDto {
                    CourseId = 3,
                    Code="C3",
                    Name="C3Name",
                    Level=101,
                    YearAndTerms = new List<YearAndTerm>{
                        new YearAndTerm {
                            AcademicYear = 2020,
                            AcademicTerms = new List<string> {"Spring","Summer"}
                        }
                    }
                }
            };
            actualCourseOptions.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task GetCoursesThatTheStudentCouldHaveEnrolled_ReturnsCourseDetailsForUnenrolledCoursesOnly_WhenStudentIdWasProvided()
        {
            var offeredCourses = new List<OfferedCourse>
            {
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 2},
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 3},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 4},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 5},
                new OfferedCourse {CourseId = 4, AcademicCalendarDetailId = 5},
                new OfferedCourse {CourseId = 4, AcademicCalendarDetailId = 6},
            };
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                },
                new AcademicCalendar {
                    AcademicCalendarId=4,
                    AcademicTermId=3,
                    Name="Spring",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=5,
                    AcademicTermId=3,
                    Name="Summer",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=6,
                    AcademicTermId=3,
                    Name="Fall",
                }
            };
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 4,
                    AcademicCalendarId=4,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,05,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 5,
                    AcademicCalendarId=5,
                    Year = 2020,
                    StartDate= new DateTime(2020,06,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 6,
                    AcademicCalendarId=6,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var courses = new List<Course> {
                new Course {
                    CourseId = 2,
                    Code = "C2",
                    Name = "C2Name",
                    Level = 101,
                    ProgramId = 2
                },
                new Course {
                    CourseId = 3,
                    Code = "C3",
                    Name = "C3Name",
                    Level = 101,
                    ProgramId = 3
                },
                new Course {
                    CourseId = 4,
                    Code = "C4",
                    Name = "C4Name",
                    Level = 101,
                    ProgramId = 3
                },
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=3,
                    AcademicCalendarDetailStartId = 4,
                }
            };
            var programs = new List<Program> {
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 3,
                    Code = "Prog3",
                    Name = "TestProg3Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var academicTerms = new List<RefAcademicTerm> {
                new RefAcademicTerm{
                    AcademicTermId= 2,
                    Name = "Bi-Semester",
                    Terms = 2
                },
                new RefAcademicTerm{
                    AcademicTermId= 3,
                    Name = "tri-Semester",
                    Terms = 3
                }
            };
            var enrolledCourses = new List<EnrolledCourse> {
                new EnrolledCourse { 
                    AcademicCalendarDetailId = 5,
                    CourseId = 3,
                    Marks = 45,
                    StudentId = 234
                }
            };

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetCoursesThatTheStudentCouldHaveEnrolled4");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.AddRange(courses);
            studentContext.AddRange(offeredCourses);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);
            studentContext.AddRange(enrolledCourses);
            studentContext.AddRange(academicTerms);

            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var actualCourseOptions = await studentRepository.GetCoursesThatTheStudentCouldHaveEnrolled(234);

            //Assert
            var expected = new List<CourseDto> {
                new CourseDto {
                    CourseId = 4,
                    Code="C4",
                    Name="C4Name",
                    Level=101,
                    YearAndTerms = new List<YearAndTerm>{
                        new YearAndTerm {
                            AcademicYear = 2020,
                            AcademicTerms = new List<string> {"Summer","Fall"}
                        }
                    }
                }
            };
            actualCourseOptions.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task AddStudentCourse_AddsEnrolledCourseReturns1_WhenProvidedAValidCourseAndStudentDetails()
        {
            //Arrange
            var offeredCourses = new List<OfferedCourse>
            {
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 2},
                new OfferedCourse {CourseId = 2, AcademicCalendarDetailId = 3},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 4},
                new OfferedCourse {CourseId = 3, AcademicCalendarDetailId = 5},
                new OfferedCourse {CourseId = 4, AcademicCalendarDetailId = 5},
                new OfferedCourse {CourseId = 4, AcademicCalendarDetailId = 6},
            };
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                },
                new AcademicCalendar {
                    AcademicCalendarId=4,
                    AcademicTermId=3,
                    Name="Spring",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=5,
                    AcademicTermId=3,
                    Name="Summer",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=6,
                    AcademicTermId=3,
                    Name="Fall",
                }
            };
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 4,
                    AcademicCalendarId=4,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,05,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 5,
                    AcademicCalendarId=5,
                    Year = 2020,
                    StartDate= new DateTime(2020,06,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 6,
                    AcademicCalendarId=6,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var courses = new List<Course> {
                new Course {
                    CourseId = 2,
                    Code = "C2",
                    Name = "C2Name",
                    Level = 101,
                    ProgramId = 2
                },
                new Course {
                    CourseId = 3,
                    Code = "C3",
                    Name = "C3Name",
                    Level = 101,
                    ProgramId = 3
                },
                new Course {
                    CourseId = 4,
                    Code = "C4",
                    Name = "C4Name",
                    Level = 101,
                    ProgramId = 4
                },
            };
            var students = new List<Student> {
                new Student{
                    StudentId = 234,
                    FirstName = "TestFName1",
                    LastName = "TestLName1",
                    ProgramId=4,
                    AcademicCalendarDetailStartId = 4,
                }
            };
            var programs = new List<Program> {
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 3,
                    Code = "Prog3",
                    Name = "TestProg3Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 4,
                    Code = "Prog4",
                    Name = "TestProg4Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                }
            };
            var enrolledCourses = new List<EnrolledCourse> { };

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("AddStudentCourse1");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(programs);
            studentContext.AddRange(students);
            studentContext.AddRange(courses);
            studentContext.AddRange(offeredCourses);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);
            studentContext.AddRange(enrolledCourses);

            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var result = await studentRepository.AddStudentCourse(234, new AddEnrolledCourseRequestDto { 
                courseId = 4,
                marks = 75,
                term = "Summer",
                year = 2020
            });

            //Assert
            result.Should().Be(1);
            studentContext.EnrolledCourses.SingleOrDefault(ec => ec.CourseId == 4 & ec.StudentId == 234 && ec.Marks == 75 && ec.AcademicCalendarDetailId == 5).Should().NotBeNull();
            
        }

        [TestMethod]
        public async Task GetAcademicCalendarDetailsByAcademicTermId_ReturnsAcademicDetailsOfThePrrogram()
        {
            //Arrange
            var academicCalenders = new List<AcademicCalendar> {
                new AcademicCalendar {
                    AcademicCalendarId = 2,
                    AcademicTermId=2,
                    Name="Spring",
                },
                new AcademicCalendar {
                    AcademicCalendarId=3,
                    AcademicTermId=2,
                    Name="Fall",
                },
                new AcademicCalendar {
                    AcademicCalendarId=4,
                    AcademicTermId=3,
                    Name="Spring",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=5,
                    AcademicTermId=3,
                    Name="Summer",
                },
                 new AcademicCalendar {
                    AcademicCalendarId=6,
                    AcademicTermId=3,
                    Name="Fall",
                }
            };
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 4,
                    AcademicCalendarId=4,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,05,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 5,
                    AcademicCalendarId=5,
                    Year = 2020,
                    StartDate= new DateTime(2020,06,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 6,
                    AcademicCalendarId=6,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var programs = new List<Program> {
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 3,
                    Code = "Prog3",
                    Name = "TestProg3Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 4,
                    Code = "Prog4",
                    Name = "TestProg4Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                }
            };

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetAcademicCalendarDetailsByAcademicTermId1");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(programs);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.AddRange(academicCalenders);
            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var result = await studentRepository.GetAcademicCalendarDetailsByAcademicTermId(4);

            //Assert
            var expectedAcademicCalendarDetails = new List<AcademicCalendarDetailOptionsDto> { 
                new AcademicCalendarDetailOptionsDto { 
                    AcademicCalendarDetailId = 4,
                    StartDate =new DateTime(2020,01,01),
                    Term = "Spring",
                    Year = 2020                    
                },
                new AcademicCalendarDetailOptionsDto {
                    AcademicCalendarDetailId = 5,
                    StartDate =new DateTime(2020,06,01),
                    Term = "Summer",
                    Year = 2020
                },
                new AcademicCalendarDetailOptionsDto {
                    AcademicCalendarDetailId = 6,
                    StartDate =new DateTime(2020,08,01),
                    Term = "Fall",
                    Year = 2020
                }
            };

            result.Should().BeEquivalentTo(expectedAcademicCalendarDetails);
        }

        [TestMethod]
        public async Task AddStudent_ReturnsTheStudentIdOfTheStudentAdded_WhenSuccessfullyAddedTheStudent()
        {

            //Arrange
            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 2,
                    AcademicCalendarId=2,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 3,
                    AcademicCalendarId=3,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 4,
                    AcademicCalendarId=4,
                    Year = 2020,
                    StartDate= new DateTime(2020,01,01),
                    StopDate=new DateTime(2020,05,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 5,
                    AcademicCalendarId=5,
                    Year = 2020,
                    StartDate= new DateTime(2020,06,01),
                    StopDate=new DateTime(2020,07,31)
                },
                new AcademicCalendarDetail{
                    AcademicCalendarDetailId = 6,
                    AcademicCalendarId=6,
                    Year = 2020,
                    StartDate= new DateTime(2020,08,01),
                    StopDate=new DateTime(2020,12,31)
                }
            };
            var students = new List<Student>();

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("AddStudent1");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(students);
            studentContext.AddRange(academicCalendarDetails);
            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var result = await studentRepository.AddStudent(new AddStudentDto { 
                AcademicDetailsStartId = 4,
                ProgramId = 3,
                FirstName = "TestFName",
                LastName = "TestLName"
            });

            //Assert
            result.Should().Be(1);
            studentContext.Students.SingleOrDefault(s => s.FirstName == "TestFName" && s.AcademicCalendarDetailStartId == 4 && s.StartDate == new DateTime(2020, 01,01)).Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetProgramsByDepartmentId_ReturnsProgramsInTheDepartment_WhenDepartmentIdIsProvided()
        {
            //Arrange
            var programs = new List<Program> {
                new Program {
                    ProgramId = 2,
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    AcademicTermId = 2,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 3,
                    Code = "Prog3",
                    Name = "TestProg3Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 2,
                },
                new Program {
                    ProgramId = 4,
                    Code = "Prog4",
                    Name = "TestProg4Name",
                    AcademicTermId = 3,
                    Active = true,
                    DepartmentId = 3,
                }
            };

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetProgramsByDepartmentId1");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(programs);
            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var result = await studentRepository.GetProgramsByDepartmentId(2);

            //Assert
            var expectedProgramData = new List<ProgramDto> {
                new ProgramDto{ 
                    Code = "Prog3",
                    Name = "TestProg3Name",
                    ProgramId = 3
                },
                new ProgramDto{
                    Code = "Prog2",
                    Name = "TestProg2Name",
                    ProgramId = 2
                }
            };

            result.Should().BeEquivalentTo(expectedProgramData);

        }

        [TestMethod]
        public async Task GetOrganizations_ReturnListOfAllOrgnizations()
        {
            //Arrange
            var organizations = new List<Organization> { 
                new Organization { 
                    Active = true,
                    Name = "TestOrg1Name",
                    OrganizationId = 1,
                    StartDate = DateTime.Today,
                    StopDate = DateTime.Today.AddDays(1),
                },
                new Organization {
                    Active = true,
                    Name = "TestOrg2Name",
                    OrganizationId = 2,
                    StartDate = DateTime.Today,
                    StopDate = DateTime.Today.AddDays(1),
                }
            };

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetOrganizations1");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(organizations);
            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var result = await studentRepository.GetOrganizations();

            //Assert
            var expectedOrgs = new List<OrganizationDto> { 
                new OrganizationDto{ 
                    OrganizationId = 1,
                    Active = true,
                    Name = "TestOrg1Name",
                    StartDate = DateTime.Today,
                    StopDate = DateTime.Today.AddDays(1)
                },
                new OrganizationDto{
                    OrganizationId = 2,
                    Active = true,
                    Name = "TestOrg2Name",
                    StartDate = DateTime.Today,
                    StopDate = DateTime.Today.AddDays(1)
                },
            };

            result.Should().BeEquivalentTo(expectedOrgs);

        }

        [TestMethod]
        public async Task GetDepartmentsbyOrganizationId_ReturnsListOfDepartmentsInAOrganization_WhenOrgnizationIdIsProvided()
        {
            //Arrange
            var departments = new List<Department> {
                new Department{
                    DepartmentId=1,
                    Code="DEP1",
                    Active=true,
                    Name= "DEPName1",
                    StartDate= DateTime.Today,
                    StopDate=DateTime.Today.AddDays(1),
                    OrganizationId=1,
                },
                new Department{
                    DepartmentId=2,
                    Code="DEP2",
                    Active=true,
                    Name= "DEPName2",
                    StartDate= DateTime.Today,
                    StopDate=DateTime.Today.AddDays(1),
                    OrganizationId=2,
                }
            };

            var builder = new DbContextOptionsBuilder<StudentContext>();
            builder.UseInMemoryDatabase("GetOrganizations1");
            var studentContext = new StudentContext(builder.Options);

            studentContext.AddRange(departments);
            studentContext.SaveChanges();

            //Act
            var studentRepository = new StudentRepository(studentContext);
            var result = await studentRepository.GetDepartmentsbyOrganizationId(2);

            //Assert
            var expectedDepartments = new List<DepartmentDto> { 
                new DepartmentDto{ 
                    Code = "DEP2",
                    DepartmentId = 2,
                    Name = "DEPName2",
                    StartDate = DateTime.Today,
                    StopDate = DateTime.Today.AddDays(1)
                }
            };

            result.Should().BeEquivalentTo(expectedDepartments);

        }

    }
}