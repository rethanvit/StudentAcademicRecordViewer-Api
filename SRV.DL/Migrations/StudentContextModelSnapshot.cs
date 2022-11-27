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
                        },
                        new
                        {
                            AcademicCalendarDetailId = 7,
                            AcademicCalendarId = 1,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2021
                        },
                        new
                        {
                            AcademicCalendarDetailId = 8,
                            AcademicCalendarId = 2,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2021, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2021
                        },
                        new
                        {
                            AcademicCalendarDetailId = 9,
                            AcademicCalendarId = 3,
                            StartDate = new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2021
                        },
                        new
                        {
                            AcademicCalendarDetailId = 10,
                            AcademicCalendarId = 4,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2021
                        },
                        new
                        {
                            AcademicCalendarDetailId = 11,
                            AcademicCalendarId = 5,
                            StartDate = new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2021, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2021
                        },
                        new
                        {
                            AcademicCalendarDetailId = 12,
                            AcademicCalendarId = 6,
                            StartDate = new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2021
                        },
                        new
                        {
                            AcademicCalendarDetailId = 13,
                            AcademicCalendarId = 1,
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2022
                        },
                        new
                        {
                            AcademicCalendarDetailId = 14,
                            AcademicCalendarId = 2,
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2022, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2022
                        },
                        new
                        {
                            AcademicCalendarDetailId = 15,
                            AcademicCalendarId = 3,
                            StartDate = new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2022
                        },
                        new
                        {
                            AcademicCalendarDetailId = 16,
                            AcademicCalendarId = 4,
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2022
                        },
                        new
                        {
                            AcademicCalendarDetailId = 17,
                            AcademicCalendarId = 5,
                            StartDate = new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2022, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2022
                        },
                        new
                        {
                            AcademicCalendarDetailId = 18,
                            AcademicCalendarId = 6,
                            StartDate = new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year = 2022
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

                    b.Property<int>("Level")
                        .HasColumnType("int");

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

                    b.HasAlternateKey("Code", "Level");

                    b.HasIndex("ProgramId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            Active = true,
                            Code = "BA",
                            Level = 101,
                            Name = "Business Administration",
                            ProgramId = 1,
                            StartDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = 2,
                            Active = true,
                            Code = "ACC",
                            Level = 101,
                            Name = "Accounts",
                            ProgramId = 1,
                            StartDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = 3,
                            Active = true,
                            Code = "FIN",
                            Level = 101,
                            Name = "Finance",
                            ProgramId = 1,
                            StartDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = 4,
                            Active = true,
                            Code = "DS",
                            Level = 101,
                            Name = "Data Structures",
                            ProgramId = 2,
                            StartDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CourseId = 5,
                            Active = true,
                            Code = "OOP",
                            Level = 101,
                            Name = "Object Oriented Prog",
                            ProgramId = 2,
                            StartDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SRV.DL.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("DepartmentId");

                    b.HasAlternateKey("Code", "Name");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
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
                            Active = true,
                            Code = "CSE",
                            MaxMarks = 100,
                            MinMarks = 40,
                            Name = "School of Computer Science",
                            OrganizationId = 1,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SRV.DL.EnrolledCourse", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("AcademicCalendarDetailId")
                        .HasColumnType("int");

                    b.Property<double>("Marks")
                        .HasColumnType("float");

                    b.HasKey("StudentId", "CourseId", "AcademicCalendarDetailId");

                    b.HasIndex("CourseId", "AcademicCalendarDetailId");

                    b.ToTable("EnrolledCourses");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            CourseId = 1,
                            AcademicCalendarDetailId = 1,
                            Marks = 45.0
                        },
                        new
                        {
                            StudentId = 1,
                            CourseId = 1,
                            AcademicCalendarDetailId = 7,
                            Marks = 45.0
                        },
                        new
                        {
                            StudentId = 1,
                            CourseId = 2,
                            AcademicCalendarDetailId = 7,
                            Marks = 45.0
                        },
                        new
                        {
                            StudentId = 1,
                            CourseId = 1,
                            AcademicCalendarDetailId = 13,
                            Marks = 45.0
                        },
                        new
                        {
                            StudentId = 1,
                            CourseId = 3,
                            AcademicCalendarDetailId = 13,
                            Marks = 45.0
                        },
                        new
                        {
                            StudentId = 2,
                            CourseId = 4,
                            AcademicCalendarDetailId = 8,
                            Marks = 45.0
                        },
                        new
                        {
                            StudentId = 2,
                            CourseId = 5,
                            AcademicCalendarDetailId = 9,
                            Marks = 45.0
                        });
                });

            modelBuilder.Entity("SRV.DL.OfferedCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("AcademicCalendarDetailId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "AcademicCalendarDetailId");

                    b.HasIndex("AcademicCalendarDetailId");

                    b.ToTable("OfferedCourses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            AcademicCalendarDetailId = 1
                        },
                        new
                        {
                            CourseId = 2,
                            AcademicCalendarDetailId = 7
                        },
                        new
                        {
                            CourseId = 3,
                            AcademicCalendarDetailId = 7
                        },
                        new
                        {
                            CourseId = 1,
                            AcademicCalendarDetailId = 7
                        },
                        new
                        {
                            CourseId = 1,
                            AcademicCalendarDetailId = 13
                        },
                        new
                        {
                            CourseId = 3,
                            AcademicCalendarDetailId = 13
                        },
                        new
                        {
                            CourseId = 4,
                            AcademicCalendarDetailId = 2
                        },
                        new
                        {
                            CourseId = 4,
                            AcademicCalendarDetailId = 3
                        },
                        new
                        {
                            CourseId = 4,
                            AcademicCalendarDetailId = 8
                        },
                        new
                        {
                            CourseId = 4,
                            AcademicCalendarDetailId = 9
                        },
                        new
                        {
                            CourseId = 4,
                            AcademicCalendarDetailId = 14
                        },
                        new
                        {
                            CourseId = 4,
                            AcademicCalendarDetailId = 15
                        },
                        new
                        {
                            CourseId = 5,
                            AcademicCalendarDetailId = 2
                        },
                        new
                        {
                            CourseId = 5,
                            AcademicCalendarDetailId = 3
                        },
                        new
                        {
                            CourseId = 5,
                            AcademicCalendarDetailId = 8
                        },
                        new
                        {
                            CourseId = 5,
                            AcademicCalendarDetailId = 9
                        },
                        new
                        {
                            CourseId = 5,
                            AcademicCalendarDetailId = 14
                        },
                        new
                        {
                            CourseId = 5,
                            AcademicCalendarDetailId = 15
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
                            Name = "LLP Institute of Business & Technology",
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

                    b.Property<int>("AcademicTermId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramId");

                    b.HasAlternateKey("Code");

                    b.HasIndex("AcademicTermId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Programs");

                    b.HasData(
                        new
                        {
                            ProgramId = 1,
                            AcademicTermId = 1,
                            Active = true,
                            Code = "MBA",
                            DepartmentId = 1,
                            Name = "Masters in Business Administration"
                        },
                        new
                        {
                            ProgramId = 2,
                            AcademicTermId = 2,
                            Active = true,
                            Code = "MCS",
                            DepartmentId = 2,
                            Name = "Masters in Computer Science"
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

                    b.Property<int>("AcademicCalendarDetailStartId")
                        .HasColumnType("int");

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

                    b.HasIndex("AcademicCalendarDetailStartId");

                    b.HasIndex("ProgramId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            AcademicCalendarDetailStartId = 7,
                            FirstName = "Johnny",
                            LastName = "Patty",
                            ProgramId = 1,
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StopDate = new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            StudentId = 2,
                            AcademicCalendarDetailStartId = 8,
                            FirstName = "Uma",
                            LastName = "Putta",
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
                    b.HasOne("SRV.DL.Organization", "Organization")
                        .WithMany("Departments")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("SRV.DL.EnrolledCourse", b =>
                {
                    b.HasOne("SRV.DL.Student", "Student")
                        .WithMany("EnrolledCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SRV.DL.OfferedCourse", "OfferedCourse")
                        .WithMany("EnrolledCourses")
                        .HasForeignKey("CourseId", "AcademicCalendarDetailId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("OfferedCourse");

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
                    b.HasOne("SRV.DL.RefAcademicTerm", "RefAcademicTerm")
                        .WithMany("Programs")
                        .HasForeignKey("AcademicTermId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SRV.DL.Department", "Department")
                        .WithMany("Programs")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("RefAcademicTerm");
                });

            modelBuilder.Entity("SRV.DL.Student", b =>
                {
                    b.HasOne("SRV.DL.AcademicCalendarDetail", "AcademicCalendarDetail")
                        .WithMany("Students")
                        .HasForeignKey("AcademicCalendarDetailStartId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SRV.DL.Program", "Program")
                        .WithMany("Students")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AcademicCalendarDetail");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("SRV.DL.AcademicCalendar", b =>
                {
                    b.Navigation("AcademicCalendarDetails");
                });

            modelBuilder.Entity("SRV.DL.AcademicCalendarDetail", b =>
                {
                    b.Navigation("OfferedCourses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SRV.DL.Course", b =>
                {
                    b.Navigation("OfferedCourses");
                });

            modelBuilder.Entity("SRV.DL.Department", b =>
                {
                    b.Navigation("Programs");
                });

            modelBuilder.Entity("SRV.DL.OfferedCourse", b =>
                {
                    b.Navigation("EnrolledCourses");
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

                    b.Navigation("Programs");
                });

            modelBuilder.Entity("SRV.DL.Student", b =>
                {
                    b.Navigation("EnrolledCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
