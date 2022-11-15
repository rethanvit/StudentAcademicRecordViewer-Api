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
        public DbSet<Student> Students { get; set; }
        public DbSet<OfferedCourses> OfferedCourses { get; set; }
        public DbSet<RefAcademicCalendar> RefAcademicCalendars { get; set; }
        public DbSet<AcademicCalendarDetail> AcademicCalendarDetails { get; set; }

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
            modelBuilder.Entity<EnrolledCourse>().HasOne(o => o.Course).WithMany(c => c.EnrolledCourses).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EnrolledCourse>().HasOne(o => o.AcademicCalendarDetail).WithMany(c => c.EnrolledCourses).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<StudentCourse>().HasAlternateKey(c => new { c.CourseId, c.StudentId, c.AcademicTermDetailId });


            modelBuilder.Entity<OfferedCourses>().HasOne(o => o.Course).WithMany(c => c.OfferedCourses).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OfferedCourses>().HasOne(o => o.AcademicCalendarDetail).WithMany(c => c.OfferedCourses).OnDelete(DeleteBehavior.NoAction);


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

            //modelBuilder.Entity<AcademicTermDetail>().HasOne(o => o.RefAcademicTerm).WithMany(c => c.AcademicTermDetails).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<AcademicTermDetail>().Property(p => p.StartDate).HasColumnType("smalldatetime");
            //modelBuilder.Entity<AcademicTermDetail>().Property(p => p.StopDate).HasColumnType("smalldatetime");
            //modelBuilder.Entity<AcademicTermDetail>().Property(p => p.Term).HasDefaultValue(0);

            modelBuilder.Entity<RefAcademicCalendar>().HasKey(p => p.AcademicCalendarId);
            modelBuilder.Entity<RefAcademicCalendar>().HasOne(p => p.RefAcademicTerm).WithMany(m => m.RefAcademicCalendars).HasForeignKey(f => f.AcademicTermId);
            modelBuilder.Entity<RefAcademicCalendar>().HasOne(o => o.RefAcademicTerm).WithMany(c => c.RefAcademicCalendars).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RefAcademicTerm>().HasKey(p => p.AcademicTermId);

            modelBuilder.Entity<AcademicCalendarDetail>().Property(p => p.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<AcademicCalendarDetail>().Property(p => p.StopDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<AcademicCalendarDetail>().HasOne(o => o.RefAcademicCalendar).WithMany(m => m.AcademicCalendarDetails).HasForeignKey(k => k.AcademicCalendarId);
            modelBuilder.Entity<AcademicCalendarDetail>().HasOne(o => o.RefAcademicCalendar).WithMany(c => c.AcademicCalendarDetails).OnDelete(DeleteBehavior.NoAction);
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
                new RefAcademicTerm { AcademicTermId = 1,Terms = 1, Name = "Annual", Active = true},
                new RefAcademicTerm { AcademicTermId = 2,Terms = 2, Name = "Semester", Active = false},
                new RefAcademicTerm { AcademicTermId = 3,Terms = 3, Name = "Quarter", Active = false}
            };
            modelBuilder.Entity<RefAcademicTerm>().HasData(academicTerms);

            var refacademicCalendars = new List<RefAcademicCalendar> {
                new RefAcademicCalendar { AcademicCalendarId = 1,Name = "Annual", AcademicTermId = 1},
                new RefAcademicCalendar { AcademicCalendarId = 2,Name = "Spring", AcademicTermId = 2},
                new RefAcademicCalendar { AcademicCalendarId = 3,Name = "Fall",   AcademicTermId = 2},
                new RefAcademicCalendar { AcademicCalendarId = 4,Name = "Spring", AcademicTermId = 3},
                new RefAcademicCalendar { AcademicCalendarId = 5,Name = "Summer", AcademicTermId = 3},
                new RefAcademicCalendar { AcademicCalendarId = 6,Name = "Fall",   AcademicTermId = 3},
            };
            modelBuilder.Entity<RefAcademicCalendar>().HasData(refacademicCalendars);

            var academicCalendarDetails = new List<AcademicCalendarDetail> {
                new AcademicCalendarDetail { AcademicCalendarDetailId = 1, Year = 2020, StartDate = new DateTime(2020,01,01), StopDate=new DateTime(2020,12,31),AcademicCalendarId = 1},
                new AcademicCalendarDetail { AcademicCalendarDetailId = 2, Year = 2020, StartDate = new DateTime(2020,01,01), StopDate=new DateTime(2020,07,31),AcademicCalendarId = 2},
                new AcademicCalendarDetail { AcademicCalendarDetailId = 3, Year = 2020, StartDate = new DateTime(2020,08,01), StopDate=new DateTime(2020,12,31),AcademicCalendarId = 3},
                new AcademicCalendarDetail { AcademicCalendarDetailId = 4, Year = 2020, StartDate = new DateTime(2020,01,01), StopDate=new DateTime(2020,05,31),AcademicCalendarId = 4},
                new AcademicCalendarDetail { AcademicCalendarDetailId = 5, Year = 2020, StartDate = new DateTime(2020,06,01), StopDate=new DateTime(2020,07,31),AcademicCalendarId = 5},
                new AcademicCalendarDetail { AcademicCalendarDetailId = 6, Year = 2020, StartDate = new DateTime(2020,08,01), StopDate=new DateTime(2020,12,31),AcademicCalendarId = 6}
            };
            modelBuilder.Entity<AcademicCalendarDetail>().HasData(academicCalendarDetails);

            //var academicTermDetails = new List<AcademicTermDetail> {
            //    new AcademicTermDetail {Id = 1, Year = 2020, Term = 0, StartDate = new DateTime(2020, 01, 01), StopDate = new DateTime(2020,02,02), RefAcademicTermId = 1},
            //    new AcademicTermDetail {Id = 2, Year = 2020, Term = 1, StartDate = new DateTime(2020, 01, 01), StopDate = new DateTime(2020,05,31), RefAcademicTermId = 2},
            //    new AcademicTermDetail {Id = 3, Year = 2020, Term = 2, StartDate = new DateTime(2020, 06, 01), StopDate = new DateTime(2020,12,31), RefAcademicTermId = 2}
            //};
            //modelBuilder.Entity<AcademicTermDetail>().HasData(academicTermDetails);

            var department = new Department { Id = 1, Code = "BUS", Name = "School of Business", AcademicTermId = 1, MaxMarks = 100, MinMarks = 40, StartDate = new DateTime(2021, 01, 01), StopDate = new DateTime(2079, 06, 06), Active = true, OrganizationId = 1 };
            modelBuilder.Entity<Department>().HasData(department);

            var courses = new List<Course> { new Course { Id = 1, Code = "MBA", Name = "Masters in Business Administration", DepartmentId = 1, OrganizationId = 1, StartDate = new DateTime(2021, 01, 01), StopDate = new DateTime(2079, 06, 06), Active = true },
                                             new Course { Id = 2, Code = "ACC", Name = "Masters in Accounts", DepartmentId = 1, OrganizationId = 1, StartDate = new DateTime(2021, 01, 01), StopDate = new DateTime(2079, 06, 06), Active = true },
                                             new Course { Id = 3, Code = "FIN", Name = "Masters in Finanace", DepartmentId = 1, OrganizationId = 1, StartDate = new DateTime(2021, 01, 01), StopDate = new DateTime(2079, 06, 06), Active = true },

            };
            modelBuilder.Entity<Course>().HasData(courses);

            var offeredCourses = new List<OfferedCourses> {
                new OfferedCourses { Id = 1, CourseId = 1, AcademicCalendarDetailId = 1 },
                new OfferedCourses { Id = 2, CourseId = 2, AcademicCalendarDetailId = 2 },
                new OfferedCourses { Id = 3, CourseId = 3, AcademicCalendarDetailId = 2 }
            };
            modelBuilder.Entity<OfferedCourses>().HasData(offeredCourses);

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
                new EnrolledCourse {Id = 1,Marks = 45, StudentId = 1, CourseId=1 ,AcademicCalendarDetailId = 1 },
                new EnrolledCourse {Id = 2,Marks = 45, StudentId = 1, CourseId=1 ,AcademicCalendarDetailId =  2},
                new EnrolledCourse {Id = 3,Marks = 45, StudentId = 2, CourseId=2 ,AcademicCalendarDetailId =  2}
            };
            modelBuilder.Entity<EnrolledCourse>().HasData(studentCourses);
        }
    }
}
