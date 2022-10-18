﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SRV.DL;

#nullable disable

namespace SRV.DL.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20221018073228_InitialSchema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SRV.DL.AcademicTermDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("RefAcademicTermId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("Term")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RefAcademicTermId");

                    b.ToTable("AcademicTermDetails");
                });

            modelBuilder.Entity("SRV.DL.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SRV.DL.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.HasKey("Id");

                    b.HasIndex("AcademicTermId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SRV.DL.EnrolledCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Marks")
                        .HasColumnType("float");

                    b.Property<int>("OfferedCoursesInTermId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfferedCoursesInTermId");

                    b.HasIndex("StudentId");

                    b.ToTable("EnrolledCourses");
                });

            modelBuilder.Entity("SRV.DL.OfferedCoursesInTerm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AcademicTermDetailId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AcademicTermDetailId");

                    b.HasIndex("CourseId");

                    b.ToTable("OfferedCoursesInTerms");
                });

            modelBuilder.Entity("SRV.DL.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("SRV.DL.RefAcademicTerm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Terms")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RefAcademicTerms");
                });

            modelBuilder.Entity("SRV.DL.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("StopDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SRV.DL.AcademicTermDetail", b =>
                {
                    b.HasOne("SRV.DL.RefAcademicTerm", "RefAcademicTerm")
                        .WithMany("AcademicTermDetails")
                        .HasForeignKey("RefAcademicTermId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("RefAcademicTerm");
                });

            modelBuilder.Entity("SRV.DL.Course", b =>
                {
                    b.HasOne("SRV.DL.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SRV.DL.Organization", "Organization")
                        .WithMany("Courses")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Organization");
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
                    b.HasOne("SRV.DL.OfferedCoursesInTerm", "OfferedCoursesInTerm")
                        .WithMany("EnrolledCourses")
                        .HasForeignKey("OfferedCoursesInTermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SRV.DL.Student", "Student")
                        .WithMany("EnrolledCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("OfferedCoursesInTerm");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SRV.DL.OfferedCoursesInTerm", b =>
                {
                    b.HasOne("SRV.DL.AcademicTermDetail", "AcademicTermDetail")
                        .WithMany("OfferedCoursesInTerms")
                        .HasForeignKey("AcademicTermDetailId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SRV.DL.Course", "Course")
                        .WithMany("OfferedCoursesInTerms")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AcademicTermDetail");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SRV.DL.Student", b =>
                {
                    b.HasOne("SRV.DL.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SRV.DL.Organization", "Organization")
                        .WithMany("Students")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("SRV.DL.AcademicTermDetail", b =>
                {
                    b.Navigation("OfferedCoursesInTerms");
                });

            modelBuilder.Entity("SRV.DL.Course", b =>
                {
                    b.Navigation("OfferedCoursesInTerms");
                });

            modelBuilder.Entity("SRV.DL.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SRV.DL.OfferedCoursesInTerm", b =>
                {
                    b.Navigation("EnrolledCourses");
                });

            modelBuilder.Entity("SRV.DL.Organization", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Departments");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SRV.DL.RefAcademicTerm", b =>
                {
                    b.Navigation("AcademicTermDetails");

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