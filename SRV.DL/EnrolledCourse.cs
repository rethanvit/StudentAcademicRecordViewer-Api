namespace SRV.DL
{
    public class EnrolledCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public double Marks { get; set; }
        public OfferedCoursesInTerm OfferedCoursesInTerm { get; set; }
        public int OfferedCoursesInTermId { get; set; }
    }
}
