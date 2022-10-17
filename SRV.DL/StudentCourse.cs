namespace SRV.DL
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int AcademicTermDetailId { get; set; }
        public AcademicTermDetail AcademicTermDetail { get; set; }
        public double Marks { get; set; }
    }
}
