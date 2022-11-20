namespace SRV.DL
{
    public class EnrolledCourse
    {
        public int EnrolledCourseId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public double Marks { get; set; }
        public OfferedCourse OfferedCourse { get; set; }
        public int OfferedCourseId { get; set; }

    }
}
