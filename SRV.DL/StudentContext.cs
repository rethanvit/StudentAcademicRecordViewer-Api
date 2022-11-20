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
        public DbSet<OfferedCourse> OfferedCourses { get; set; }
        public DbSet<AcademicCalendar> AcademicCalendars { get; set; }
        public DbSet<AcademicCalendarDetail> AcademicCalendarDetails { get; set; }
        public DbSet<Program> Programs { get; set; }

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
            modelBuilder.Entity<Course>().HasOne(o => o.Program).WithMany(c => c.Courses).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Course>().Property(d => d.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Course>().Property(d => d.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Course>().Property(d => d.StopDate).HasColumnType("smalldatetime");

            modelBuilder.Entity<Program>().HasOne(d => d.Department).WithMany(p => p.Programs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Program>().HasOne(p => p.RefAcademicTerm).WithMany(m => m.Programs).HasForeignKey(f => f.AcademicTermId);

            modelBuilder.Entity<EnrolledCourse>().HasOne(o => o.Student).WithMany(c => c.EnrolledCourses).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EnrolledCourse>().HasOne(o => o.OfferedCourse).WithOne(c => c.EnrolledCourse).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EnrolledCourse>().HasAlternateKey(d => new { d.StudentId, d.OfferedCourseId });
            //modelBuilder.Entity<EnrolledCourse>().HasOne(o => o.AcademicCalendarDetail).WithMany(c => c.EnrolledCourses).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<OfferedCourse>().HasOne(o => o.Course).WithMany(c => c.OfferedCourses).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OfferedCourse>().HasOne(o => o.AcademicCalendarDetail).WithMany(c => c.OfferedCourses).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Department>().HasOne(o => o.Organization).WithMany(c => c.Departments).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Department>().Property(d => d.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Department>().Property(d => d.StopDate).HasColumnType("smalldatetime");
            //set default value
            modelBuilder.Entity<Department>().Property(a => a.MaxMarks).HasDefaultValue(100);
            modelBuilder.Entity<Department>().Property(a => a.MinMarks).HasDefaultValue(40);

            modelBuilder.Entity<Student>().HasOne(o => o.Program).WithMany(c => c.Students).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Student>().Property(d => d.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Student>().Property(d => d.StopDate).HasColumnType("smalldatetime");
            

            modelBuilder.Entity<AcademicCalendar>().HasKey(p => p.AcademicCalendarId);
            modelBuilder.Entity<AcademicCalendar>().HasOne(p => p.RefAcademicTerm).WithMany(m => m.AcademicCalendars).HasForeignKey(f => f.AcademicTermId);
            modelBuilder.Entity<AcademicCalendar>().HasOne(o => o.RefAcademicTerm).WithMany(c => c.AcademicCalendars).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RefAcademicTerm>().HasKey(p => p.AcademicTermId);

            modelBuilder.Entity<AcademicCalendarDetail>().Property(p => p.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<AcademicCalendarDetail>().Property(p => p.StopDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<AcademicCalendarDetail>().HasOne(o => o.RefAcademicCalendar).WithMany(m => m.AcademicCalendarDetails).HasForeignKey(k => k.AcademicCalendarId);
            modelBuilder.Entity<AcademicCalendarDetail>().HasOne(o => o.RefAcademicCalendar).WithMany(c => c.AcademicCalendarDetails).OnDelete(DeleteBehavior.NoAction);

            //start with prinicipal or parent table in 1:1 relation.
            //modelBuilder.Entity<RefAcademicSystem>().HasOne(b => b.Department).WithOne().HasForeignKey<Department>(f => f.AcademicSystemId);
            //modelBuilder.Entity<RefAcademicSystem>().HasOne(b => b.StudentCourse).WithOne().HasForeignKey<StudentCourse>(f => f.AcademicSystemId);

            //configure AcademicTerms as PK for RefAcademicSystem entity
            //modelBuilder.Entity<RefAcademicTerm>().HasKey(p => p.);


            modelBuilder.Entity<Organization>().Property(a => a.StartDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<Organization>().Property(a => a.StopDate).HasColumnType("smalldatetime");



            //seed data
            //Even when Identity is turned off EF inserts Id value as shown below
            //var organizations = new List<Organization>{
            //    new Organization { OrganizationId = 1, Name = "LLP School of Business", StartDate = new DateTime(2021, 01, 01), StopDate = new DateTime(2079, 06, 06), Active = true },
            //    new Organization { OrganizationId = 2, Name = "LLC School of Engineering", StartDate = new DateTime(2021, 01, 01), StopDate = new DateTime(2079, 06, 06), Active = true }
            //};
            //modelBuilder.Entity<Organization>().HasData(organizations);

            //var departments = new List<Department>{
            //    new Department { DepartmentId = 1, Code = "BUS", Name = "School of Business", MaxMarks = 100, MinMarks = 40, StartDate = new DateTime(2021, 01, 01),
            //        StopDate = new DateTime(2079, 06, 06), Active = true, OrganizationId = 1 },
            //    new Department { DepartmentId = 2, Code = "ENG", Name = "School of Computer Science", MaxMarks = 75, MinMarks = 40, StartDate = new DateTime(2021, 01, 01),
            //        StopDate = new DateTime(2079, 06, 06), Active = true, OrganizationId = 2 }
            //};
            //modelBuilder.Entity<Department>().HasData(departments);

            //var academicTerms = new List<RefAcademicTerm> {
            //    new RefAcademicTerm { AcademicTermId = 1,Terms = 1, Name = "Annual", Active = true},
            //    new RefAcademicTerm { AcademicTermId = 2,Terms = 2, Name = "Semester", Active = false},
            //    new RefAcademicTerm { AcademicTermId = 3,Terms = 3, Name = "Quarter", Active = false}
            //};
            //modelBuilder.Entity<RefAcademicTerm>().HasData(academicTerms);

            //var programs = new List<Program> {
            //    new Program {ProgramId = 1, Code="MBA", Name = "Masters in Business Administration", DepartmentId = 1, AcademicTermId = 1, Active = true},
            //    new Program {ProgramId = 2, Code="MCS", Name = "Masters in Computer Science", DepartmentId = 2, AcademicTermId = 1,Active = true},
            //    new Program {ProgramId = 3, Code="BCS", Name = "Bachelors in Computer Science", DepartmentId = 2, AcademicTermId = 1,Active = true},
            //};
            //modelBuilder.Entity<Program>().HasData(programs);

            //var academicCalendars = new List<AcademicCalendar> {
            //    new AcademicCalendar { AcademicCalendarId = 1,Name = "Annual", AcademicTermId = 1},
            //    new AcademicCalendar { AcademicCalendarId = 2,Name = "Spring", AcademicTermId = 2},
            //    new AcademicCalendar { AcademicCalendarId = 3,Name = "Fall",   AcademicTermId = 2},
            //    new AcademicCalendar { AcademicCalendarId = 4,Name = "Spring", AcademicTermId = 3},
            //    new AcademicCalendar { AcademicCalendarId = 5,Name = "Summer", AcademicTermId = 3},
            //    new AcademicCalendar { AcademicCalendarId = 6,Name = "Fall",   AcademicTermId = 3},
            //};
            //modelBuilder.Entity<AcademicCalendar>().HasData(academicCalendars);

            //var academicCalendarDetails = new List<AcademicCalendarDetail> {
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 1, Year = 2020, StartDate = new DateTime(2020,01,01), StopDate=new DateTime(2020,12,31),AcademicCalendarId = 1},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 2, Year = 2020, StartDate = new DateTime(2020,01,01), StopDate=new DateTime(2020,07,31),AcademicCalendarId = 2},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 3, Year = 2020, StartDate = new DateTime(2020,08,01), StopDate=new DateTime(2020,12,31),AcademicCalendarId = 3},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 4, Year = 2020, StartDate = new DateTime(2020,01,01), StopDate=new DateTime(2020,05,31),AcademicCalendarId = 4},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 5, Year = 2020, StartDate = new DateTime(2020,06,01), StopDate=new DateTime(2020,07,31),AcademicCalendarId = 5},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 6, Year = 2020, StartDate = new DateTime(2020,08,01), StopDate=new DateTime(2020,12,31),AcademicCalendarId = 6},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 7, Year = 2021, StartDate = new DateTime(2021,01,01), StopDate=new DateTime(2021,12,31),AcademicCalendarId = 1},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 8, Year = 2021, StartDate = new DateTime(2021,01,01), StopDate=new DateTime(2021,07,31),AcademicCalendarId = 2},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 9, Year = 2021, StartDate = new DateTime(2021,08,01), StopDate=new DateTime(2021,12,31),AcademicCalendarId = 3},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 10, Year = 2021, StartDate = new DateTime(2021,01,01), StopDate=new DateTime(2021,05,31),AcademicCalendarId = 4},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 11, Year = 2021, StartDate = new DateTime(2021,06,01), StopDate=new DateTime(2021,07,31),AcademicCalendarId = 5},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 12, Year = 2021, StartDate = new DateTime(2021,08,01), StopDate=new DateTime(2021,12,31),AcademicCalendarId = 6},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 13, Year = 2022, StartDate = new DateTime(2022,01,01), StopDate=new DateTime(2022,12,31),AcademicCalendarId = 1},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 14, Year = 2022, StartDate = new DateTime(2022,01,01), StopDate=new DateTime(2022,07,31),AcademicCalendarId = 2},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 15, Year = 2022, StartDate = new DateTime(2022,08,01), StopDate=new DateTime(2022,12,31),AcademicCalendarId = 3},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 16, Year = 2022, StartDate = new DateTime(2022,01,01), StopDate=new DateTime(2022,05,31),AcademicCalendarId = 4},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 17, Year = 2022, StartDate = new DateTime(2022,06,01), StopDate=new DateTime(2022,07,31),AcademicCalendarId = 5},
            //    new AcademicCalendarDetail { AcademicCalendarDetailId = 18, Year = 2022, StartDate = new DateTime(2022,08,01), StopDate=new DateTime(2022,12,31),AcademicCalendarId = 6}
            //};
            //modelBuilder.Entity<AcademicCalendarDetail>().HasData(academicCalendarDetails);

            //var courses = new List<Course> {
            //    new Course { CourseId = 1, Code = "BA", Level=101, Name = "Business Administration", ProgramId = 1, StartDate = new DateTime(2020, 01, 01),
            //        StopDate = new DateTime(2079, 06, 06), Active = true },
            //    new Course { CourseId = 2, Code = "ACC", Level=101, Name = "Accounts", ProgramId = 1, StartDate = new DateTime(2020, 01, 01),
            //        StopDate = new DateTime(2079, 06, 06), Active = true },
            //    new Course { CourseId = 3, Code = "FIN", Level=101, Name = "Finance", ProgramId = 1, StartDate = new DateTime(2020, 01, 01),
            //        StopDate = new DateTime(2079, 06, 06), Active = true },
            //    new Course { CourseId = 4, Code = "DS", Level=101, Name = "Data Structures", ProgramId = 2, StartDate = new DateTime(2020, 01, 01),
            //        StopDate = new DateTime(2079, 06, 06), Active = true },

            //};
            //modelBuilder.Entity<Course>().HasData(courses);

            //var offeredCourses = new List<OfferedCourse> {
            //    new OfferedCourse { OfferedCourseId = 1, CourseId = 1, AcademicCalendarDetailId = 1 },
            //    new OfferedCourse { OfferedCourseId = 2, CourseId = 2, AcademicCalendarDetailId = 2 },
            //    new OfferedCourse { OfferedCourseId = 3, CourseId = 3, AcademicCalendarDetailId = 2 }
            //};
            //modelBuilder.Entity<OfferedCourse>().HasData(offeredCourses);

            //var student = new List<Student> {
            //    new Student { StudentId = 1, FirstName = "Johnny", LastName="Patty",ProgramId = 1, StartDate = new DateTime(2021,01,01), StopDate = new DateTime(2079,06,06), AcademicCalendarDetailId = 7},
            //    new Student { StudentId = 2, FirstName = "Alia", LastName="Thomson",ProgramId = 2, StartDate = new DateTime(2021,01,01), StopDate = new DateTime(2079,06,06), AcademicCalendarDetailId = 7}
            //};
            //modelBuilder.Entity<Student>().HasData(student);

            //var studentCourses = new List<EnrolledCourse>
            //{
            //    new EnrolledCourse {EnrolledCourseId = 1,Marks = 45, StudentId = 1, OfferedCourseId=1},
            //    new EnrolledCourse {EnrolledCourseId = 2,Marks = 45, StudentId = 1, OfferedCourseId=2},
            //    new EnrolledCourse {EnrolledCourseId = 3,Marks = 45, StudentId = 2, OfferedCourseId=3}
            //};
            //modelBuilder.Entity<EnrolledCourse>().HasData(studentCourses);
        }
    }
}
