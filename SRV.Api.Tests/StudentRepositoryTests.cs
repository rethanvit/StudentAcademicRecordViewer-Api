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
            builder.UseInMemoryDatabase("GetStudentByIdAsync");
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
            builder.UseInMemoryDatabase("GetStudentByIdAsync");
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
            builder.UseInMemoryDatabase("GetStudentAndEnrolledCourseAsync");
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
            builder.UseInMemoryDatabase("GetStudentAndEnrolledCourseAsync");
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
            builder.UseInMemoryDatabase("DeleteCoursesEnrolled");
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

            await studentRepository.DeleteCoursesEnrolled(234, courseToBeDeleted);

            //Assert
            studentContext.EnrolledCourses.SingleOrDefault(ec => ec.CourseId == 3).Should().BeNull();
            studentContext.EnrolledCourses.SingleOrDefault(ec => ec.CourseId == 2).Should().NotBeNull();

        }
    }
}