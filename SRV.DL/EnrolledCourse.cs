namespace SRV.DL
{
    public class EnrolledCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public double Marks { get; set; }
        public AcademicCalendarDetail AcademicCalendarDetail { get; set; }
        public int AcademicCalendarDetailId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }

    }
}
