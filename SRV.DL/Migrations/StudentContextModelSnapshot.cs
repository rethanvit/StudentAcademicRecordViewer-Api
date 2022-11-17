﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SRV.DL;

#nullable disable

namespace SRV.DL.Migrations
{
    [DbContext(typeof(StudentContext))]
    partial class StudentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SRV.DL.AcademicCalendar", b =>
                {
                    b.Property<int>("AcademicCalendarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcademicCalendarId"), 1L, 1);

                    b.Property<int>("AcademicTermId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcademicCalendarId");

                    b.HasIndex("AcademicTermId");

                    b.ToTable("AcademicCalendars");

                    b.HasData(
                        new
                        {
                            AcademicCalendarId = 1,
                            AcademicTermId = 1,
                            Name = "Annual"
                        },
                        new
                        {
                            AcademicCalendarId = 2,
                            AcademicTermId = 2,
                            Name = "Spring"
                        },
                        new
                        {
                            AcademicCalendarId = 3,
                            AcademicTermId = 2,
                            Name = "Fall"
                        },
                        new
                        {
                            AcademicCalendarId = 4,
                            AcademicTermId = 3,
                            Name = "Spring"
                        },
                        new
                        {
                            AcademicCalendarId = 5,
                            AcademicTermId = 3,
                            Name = "Summer"
                        },
                        new
                        {
                            AcademicCalendarId = 6,
                            AcademicTermId = 3,
                            Name = "Fall"
                        });
                });

            modelBuilder.Entity("SRV.DL.AcademicCalendarDetail", b =>
                {
                    b.Property<int>("AcademicCalendarDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcademicCalendarDetailId"), 1L, 1);

                    b.Property<int>("AcademicCalendarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("AcademicCalendarDetailId");

                    b.HasIndex("AcademicCalendarId");

                    b.ToTable("AcademicCalendarDetails");

                    b.HasData(
                        new
                        {
                            AcademicCalendarDetailId = 1,
                            AcademicCalendarId = 1,
                            StartDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2020
                        },
                        new
                        {
                            AcademicCalendarDetailId = 2,
                            AcademicCalendarId = 2,
                            StartDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2020
                        },
                        new
                        {
                            AcademicCalendarDetailId = 3,
                            AcademicCalendarId = 3,
                            StartDate = new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2020
                        },
                        new
                        {
                            AcademicCalendarDetailId = 4,
                            AcademicCalendarId = 4,
                            StartDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2020
                        },
                        new
                        {
                            AcademicCalendarDetailId = 5,
                            AcademicCalendarId = 5,
                            StartDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2020
                        },
                        new
                        {
                            AcademicCalendarDetailId = 6,
                            AcademicCalendarId = 6,
                            StartDate = new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2020
                        });
                });

            modelBuilder.Entity("SRV.DL.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("CourseId");

                    b.HasIndex("ProgramId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            Active = true,
                            Code = "MBA",
                            Name = "Business Administration 101",
                            ProgramId = 1,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = 2,
                            Active = true,
                            Code = "ACC",
                            Name = "Accounts 101",
                            ProgramId = 1,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = 3,
                            Active = true,
                            Code = "FIN",
                            Name = "Finance 101",
                            ProgramId = 1,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = 4,
                            Active = true,
                            Code = "CSE",
                            Name = "Data Structures",
                            ProgramId = 2,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SRV.DL.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<int>("AcademicTermId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("MaxMarks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(100);

                    b.Property<int>("MinMarks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(40);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("DepartmentId");

                    b.HasIndex("AcademicTermId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            AcademicTermId = 1,
                            Active = true,
                            Code = "BUS",
                            MaxMarks = 100,
                            MinMarks = 40,
                            Name = "School of Business",
                            OrganizationId = 1,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DepartmentId = 2,
                            AcademicTermId = 1,
                            Active = true,
                            Code = "ENG",
                            MaxMarks = 75,
                            MinMarks = 40,
                            Name = "School of Computer Science",
                            OrganizationId = 2,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SRV.DL.EnrolledCourse", b =>
                {
                    b.Property<int>("EnrolledCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrolledCourseId"), 1L, 1);

                    b.Property<int>("AcademicCalendarDetailId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<double>("Marks")
                        .HasColumnType("float");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("EnrolledCourseId");

                    b.HasIndex("AcademicCalendarDetailId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("EnrolledCourses");

                    b.HasData(
                        new
                        {
                            EnrolledCourseId = 1,
                            AcademicCalendarDetailId = 1,
                            CourseId = 1,
                            Marks = 45.0,
                            StudentId = 1
                        },
                        new
                        {
                            EnrolledCourseId = 2,
                            AcademicCalendarDetailId = 2,
                            CourseId = 1,
                            Marks = 45.0,
                            StudentId = 1
                        },
                        new
                        {
                            EnrolledCourseId = 3,
                            AcademicCalendarDetailId = 2,
                            CourseId = 2,
                            Marks = 45.0,
                            StudentId = 2
                        });
                });

            modelBuilder.Entity("SRV.DL.OfferedCourse", b =>
                {
                    b.Property<int>("OfferedCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfferedCourseId"), 1L, 1);

                    b.Property<int>("AcademicCalendarDetailId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("OfferedCourseId");

                    b.HasIndex("AcademicCalendarDetailId");

                    b.HasIndex("CourseId");

                    b.ToTable("OfferedCourses");

                    b.HasData(
                        new
                        {
                            OfferedCourseId = 1,
                            AcademicCalendarDetailId = 1,
                            CourseId = 1
                        },
                        new
                        {
                            OfferedCourseId = 2,
                            AcademicCalendarDetailId = 2,
                            CourseId = 2
                        },
                        new
                        {
                            OfferedCourseId = 3,
                            AcademicCalendarDetailId = 2,
                            CourseId = 3
                        });
                });

            modelBuilder.Entity("SRV.DL.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizationId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            OrganizationId = 1,
                            Active = true,
                            Name = "LLP School of Business",
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            OrganizationId = 2,
                            Active = true,
                            Name = "LLC School of Engineering",
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SRV.DL.Program", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgramId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Programs");

                    b.HasData(
                        new
                        {
                            ProgramId = 1,
                            Active = true,
                            DepartmentId = 1,
                            Name = "Masters in Business Administration"
                        },
                        new
                        {
                            ProgramId = 2,
                            Active = true,
                            DepartmentId = 2,
                            Name = "Masters in Computer Science"
                        },
                        new
                        {
                            ProgramId = 3,
                            Active = true,
                            DepartmentId = 2,
                            Name = "Bachelors in Computer Science"
                        });
                });

            modelBuilder.Entity("SRV.DL.RefAcademicTerm", b =>
                {
                    b.Property<int>("AcademicTermId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcademicTermId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Terms")
                        .HasColumnType("int");

                    b.HasKey("AcademicTermId");

                    b.ToTable("RefAcademicTerms");

                    b.HasData(
                        new
                        {
                            AcademicTermId = 1,
                            Active = true,
                            Name = "Annual",
                            Terms = 1
                        },
                        new
                        {
                            AcademicTermId = 2,
                            Active = false,
                            Name = "Semester",
                            Terms = 2
                        },
                        new
                        {
                            AcademicTermId = 3,
                            Active = false,
                            Name = "Quarter",
                            Terms = 3
                        });
                });

            modelBuilder.Entity("SRV.DL.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("StudentId");

                    b.HasIndex("ProgramId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            FirstName = "Johnny",
                            LastName = "Patty",
                            ProgramId = 1,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            StudentId = 2,
                            FirstName = "Alia",
                            LastName = "Thomson",
                            ProgramId = 2,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SRV.DL.AcademicCalendar", b =>
                {
                    b.HasOne("SRV.DL.RefAcademicTerm", "RefAcademicTerm")
                        .WithMany("AcademicCalendars")
                        .HasForeignKey("AcademicTermId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("RefAcademicTerm");
                });

            modelBuilder.Entity("SRV.DL.AcademicCalendarDetail", b =>
                {
                    b.HasOne("SRV.DL.AcademicCalendar", "RefAcademicCalendar")
                        .WithMany("AcademicCalendarDetails")
                        .HasForeignKey("AcademicCalendarId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("RefAcademicCalendar");
                });

            modelBuilder.Entity("SRV.DL.Course", b =>
                {
                    b.HasOne("SRV.DL.Program", "Program")
                        .WithMany("Courses")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Program");
                });

            modelBuilder.Entity("SRV.DL.Department", b =>
                {
                    b.HasOne("SRV.DL.RefAcademicTerm", "RefAcademicTerm")
                        .WithMany("Departments")
                        .HasForeignKey("AcademicTermId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SRV.DL.Organization", "Organization")
                        .WithMany("Departments")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("RefAcademicTerm");
                });

            modelBuilder.Entity("SRV.DL.EnrolledCourse", b =>
                {
                    b.HasOne("SRV.DL.AcademicCalendarDetail", "AcademicCalendarDetail")
                        .WithMany("EnrolledCourses")
                        .HasForeignKey("AcademicCalendarDetailId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SRV.DL.Course", "Course")
                        .WithMany("EnrolledCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SRV.DL.Student", "Student")
                        .WithMany("EnrolledCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AcademicCalendarDetail");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SRV.DL.OfferedCourse", b =>
                {
                    b.HasOne("SRV.DL.AcademicCalendarDetail", "AcademicCalendarDetail")
                        .WithMany("OfferedCourses")
                        .HasForeignKey("AcademicCalendarDetailId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SRV.DL.Course", "Course")
                        .WithMany("OfferedCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AcademicCalendarDetail");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SRV.DL.Program", b =>
                {
                    b.HasOne("SRV.DL.Department", "Department")
                        .WithMany("Programs")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SRV.DL.Student", b =>
                {
                    b.HasOne("SRV.DL.Program", "Program")
                        .WithMany("Students")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Program");
                });

            modelBuilder.Entity("SRV.DL.AcademicCalendar", b =>
                {
                    b.Navigation("AcademicCalendarDetails");
                });

            modelBuilder.Entity("SRV.DL.AcademicCalendarDetail", b =>
                {
                    b.Navigation("EnrolledCourses");

                    b.Navigation("OfferedCourses");
                });

            modelBuilder.Entity("SRV.DL.Course", b =>
                {
                    b.Navigation("EnrolledCourses");

                    b.Navigation("OfferedCourses");
                });

            modelBuilder.Entity("SRV.DL.Department", b =>
                {
                    b.Navigation("Programs");
                });

            modelBuilder.Entity("SRV.DL.Organization", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("SRV.DL.Program", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SRV.DL.RefAcademicTerm", b =>
                {
                    b.Navigation("AcademicCalendars");

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("SRV.DL.Student", b =>
                {
                    b.Navigation("EnrolledCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
