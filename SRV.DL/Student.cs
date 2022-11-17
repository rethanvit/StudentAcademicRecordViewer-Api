namespace SRV.DL
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public int ProgramId { get; set; }
        public Program Program { get; set; }
        public List<EnrolledCourse> EnrolledCourses { get; set; }
    }
}
