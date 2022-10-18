using Microsoft.EntityFrameworkCore;

namespace SRV.DL
{
    internal class StudentContext: DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<RefAcademicTerm> RefAcademicTerms { get; set; }
        public DbSet<EnrolledCourse> EnrolledCourses { get; set; }
        public DbSet<AcademicTermDetail> AcademicTermDetails { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfferedCoursesInTerm> OfferedCoursesInTerms { get; set; }

        public StudentContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SRVTest");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //start with entity which has navigation property in child table in 1:* relation.
            modelBuilder.Entity<Course>().HasOne(o => o.Organization).WithMany(c => c.Courses).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Course>().HasOne(o => o.Department).WithMany(c => c.Courses).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Course>().Property(d => d.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Course>().Property(d => d.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Course>().Property(d => d.StopDate).HasColumnType("smalldatetime");

            //modelBuilder.Entity<StudentCourse>().HasOne(o => o.Course).WithMany(c => c.StudentCourses).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EnrolledCourse>().HasOne(o => o.Student).WithMany(c => c.EnrolledCourses).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<StudentCourse>().HasOne(o => o.AcademicTermDetail).WithMany(c => c.StudentCourses).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<StudentCourse>().HasAlternateKey(c => new { c.CourseId, c.StudentId, c.AcademicTermDetailId });


            modelBuilder.Entity<OfferedCoursesInTerm>().HasOne(o => o.Course).WithMany(c => c.OfferedCoursesInTerms).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OfferedCoursesInTerm>().HasOne(o => o.AcademicTermDetail).WithMany(c => c.OfferedCoursesInTerms).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Department>().HasOne(o => o.RefAcademicTerm).WithMany(b => b.Departments).HasForeignKey(d => d.AcademicTermId);
            modelBuilder.Entity<Department>().HasOne(o => o.RefAcademicTerm).WithMany(c => c.Departments).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Department>().HasOne(o => o.Organization).WithMany(c => c.Departments).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Department>().Property(d => d.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Department>().Property(d => d.StopDate).HasColumnType("smalldatetime");
            //set default value
            modelBuilder.Entity<Department>().Property(a => a.MaxMarks).HasDefaultValue(100);
            modelBuilder.Entity<Department>().Property(a => a.MinMarks).HasDefaultValue(40);

            modelBuilder.Entity<Student>().HasOne(o => o.Organization).WithMany(c => c.Students).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Student>().HasOne(o => o.Department).WithMany(c => c.Students).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Student>().Property(d => d.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Student>().Property(d => d.StopDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<AcademicTermDetail>().HasOne(o => o.RefAcademicTerm).WithMany(c => c.AcademicTermDetails).OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<AcademicTermDetail>().Property(p => p.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<AcademicTermDetail>().Property(p => p.StopDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<AcademicTermDetail>().Property(p => p.Term).HasDefaultValue(0);
            //modelBuilder.Entity<StudentCourse>().HasOne(o => o.RefAcademicSystem).WithMany(b => b.StudentCourses).HasForeignKey(d => d.AcademicSystemId);
            //modelBuilder.Entity<StudentCourse>().HasOne(o => o.RefAcademicSystem).WithMany(c => c.StudentCourses).OnDelete(DeleteBehavior.NoAction);

            //start with prinicipal or parent table in 1:1 relation.
            //modelBuilder.Entity<RefAcademicSystem>().HasOne(b => b.Department).WithOne().HasForeignKey<Department>(f => f.AcademicSystemId);
            //modelBuilder.Entity<RefAcademicSystem>().HasOne(b => b.StudentCourse).WithOne().HasForeignKey<StudentCourse>(f => f.AcademicSystemId);

            //configure AcademicTerms as PK for RefAcademicSystem entity
            //modelBuilder.Entity<RefAcademicTerm>().HasKey(p => p.);


            modelBuilder.Entity<Organization>().Property(a => a.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Organization>().Property(a => a.StopDate).HasColumnType("smalldatetime");



            //seed data
            //Even when Identity is turned off EF inserts Id value as shown below
            var organization = new Organization { Id = 1, Name = "LLC School of Business", StartDate = new DateTime(2021, 01, 01), StopDate = new DateTime(2079, 06, 06), Active = true };
            modelBuilder.Entity<Organization>().HasData(organization);

            var academicTerms = new List<RefAcademicTerm> {
                new RefAcademicTerm { Id = 1,Terms = 1, Name = "Annual", Active = true},
                new RefAcademicTerm { Id = 2,Terms = 2, Name = "Semester", Active = false},
                new RefAcademicTerm { Id = 3,Terms = 3, Name = "Quarter", Active = false}
            };
            modelBuilder.Entity<RefAcademicTerm>().HasData(academicTerms);

            var academicTermDetails = new List<AcademicTermDetail> {
                new AcademicTermDetail {Id = 1, Year = 2020, Term = 0, StartDate = new DateTime(2020, 01, 01), StopDate = new DateTime(2020,02,02), RefAcademicTermId = 1},
                new AcademicTermDetail {Id = 2, Year = 2020, Term = 1, StartDate = new DateTime(2020, 01, 01), StopDate = new DateTime(2020,05,31), RefAcademicTermId = 2},
                new AcademicTermDetail {Id = 3, Year = 2020, Term = 2, StartDate = new DateTime(2020, 06, 01), StopDate = new DateTime(2020,12,31), RefAcademicTermId = 2}
            };
            modelBuilder.Entity<AcademicTermDetail>().HasData(academicTermDetails);

            var department = new Department { Id = 1, Code = "BUS", Name = "School of Business", AcademicTermId = 1, MaxMarks = 100, MinMarks = 40, StartDate = new DateTime(2021, 01, 01), StopDate = new DateTime(2079, 06, 06), Active = true, OrganizationId = 1 };
            modelBuilder.Entity<Department>().HasData(department);

            var courses = new List<Course> { new Course { Id = 1, Code = "MBA", Name = "Masters in Business Administration", DepartmentId = 1, OrganizationId = 1, StartDate = new DateTime(2021, 01, 01), StopDate = new DateTime(2079, 06, 06), Active = true },
                                             new Course { Id = 2, Code = "ACC", Name = "Masters in Accounts", DepartmentId = 1, OrganizationId = 1, StartDate = new DateTime(2021, 01, 01), StopDate = new DateTime(2079, 06, 06), Active = true },
                                             new Course { Id = 3, Code = "FIN", Name = "Masters in Finanace", DepartmentId = 1, OrganizationId = 1, StartDate = new DateTime(2021, 01, 01), StopDate = new DateTime(2079, 06, 06), Active = true },

            };
            modelBuilder.Entity<Course>().HasData(courses);

            var offeredCoursesInTerm = new List<OfferedCoursesInTerm> {
                new OfferedCoursesInTerm { Id = 1, CourseId = 1, AcademicTermDetailId = 1 },
                new OfferedCoursesInTerm { Id = 2, CourseId = 2, AcademicTermDetailId = 2 },
                new OfferedCoursesInTerm { Id = 3, CourseId = 3, AcademicTermDetailId = 2 }
            };
            modelBuilder.Entity<OfferedCoursesInTerm>().HasData(offeredCoursesInTerm);

            //var joinEntityStudentCoursesOfferedCourses = new List<object> { new { OfferedCoursesInTermsId  = 1, EnrolledCoursesId = 1 },
            //                                                                new { OfferedCoursesInTermsId  = 1, EnrolledCoursesId = 2 },
            //                                                                new { OfferedCoursesInTermsId = 2, EnrolledCoursesId = 3 }
            //};
            //modelBuilder.Entity<EnrolledCourse>().HasMany(c => c.OfferedCoursesInTerms).WithMany(d => d.EnrolledCourses).UsingEntity(e => e.HasData(joinEntityStudentCoursesOfferedCourses));

            var student = new List<Student> {
                new Student { Id = 1, FirstName = "Johnny", LastName="Patty",DepartmentId = 1, OrganizationId = 1, StartDate = new DateTime(2021,01,01), StopDate = new DateTime(2079,06,06)},
                new Student { Id = 2, FirstName = "Alia", LastName="Thomson",DepartmentId = 1, OrganizationId = 1, StartDate = new DateTime(2021,01,01), StopDate = new DateTime(2079,06,06)}
            };
            modelBuilder.Entity<Student>().HasData(student);

            var studentCourses = new List<EnrolledCourse>
            {
                new EnrolledCourse {Id = 1,Marks = 45, StudentId = 1, OfferedCoursesInTermId = 1 },
                new EnrolledCourse {Id = 2,Marks = 45, StudentId = 1, OfferedCoursesInTermId =  2},
                new EnrolledCourse {Id = 3,Marks = 45, StudentId = 2, OfferedCoursesInTermId =  3}
            };
            modelBuilder.Entity<EnrolledCourse>().HasData(studentCourses);
        }
    }
}
