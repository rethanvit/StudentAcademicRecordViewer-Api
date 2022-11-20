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

                    b.HasIndex("ProgramId");

                    b.ToTable("Courses");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("DepartmentId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SRV.DL.EnrolledCourse", b =>
                {
                    b.Property<int>("EnrolledCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrolledCourseId"), 1L, 1);

                    b.Property<double>("Marks")
                        .HasColumnType("float");

                    b.Property<int>("OfferedCourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("EnrolledCourseId");

                    b.HasAlternateKey("StudentId", "OfferedCourseId");

                    b.HasIndex("OfferedCourseId")
                        .IsUnique();

                    b.ToTable("EnrolledCourses");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramId");

                    b.HasIndex("AcademicTermId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Programs");
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
                });

            modelBuilder.Entity("SRV.DL.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<int>("AcademicCalendarDetailId")
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

                    b.HasIndex("AcademicCalendarDetailId");

                    b.HasIndex("ProgramId");

                    b.ToTable("Students");
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
                    b.HasOne("SRV.DL.OfferedCourse", "OfferedCourse")
                        .WithOne("EnrolledCourse")
                        .HasForeignKey("SRV.DL.EnrolledCourse", "OfferedCourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SRV.DL.Student", "Student")
                        .WithMany("EnrolledCourses")
                        .HasForeignKey("StudentId")
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
                        .OnDelete(DeleteBehavior.Cascade)
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
                        .HasForeignKey("AcademicCalendarDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
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
                    b.Navigation("EnrolledCourse")
                        .IsRequired();
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
