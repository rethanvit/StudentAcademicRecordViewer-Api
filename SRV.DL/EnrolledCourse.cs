namespace SRV.DL
{
    public class EnrolledCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public double Marks { get; set; }
        public OfferedCourse OfferedCourse { get; set; }
        public int CourseId { get; set; }
        public int AcademicCalendarDetailId { get; set; }

    }
}
