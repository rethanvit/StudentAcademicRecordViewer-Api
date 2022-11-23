namespace SRV.Api.Models
{
    public class StudentCourseArgs
    {
        public int StudentId { get; set; }
        public string StudentProgramCode { get; set; }
        public string CourseCode { get; set; }
        public int CourseLevel { get; set; }
        public int Academicyear { get; set; }
        public string AcademicTerm { get; set; }
    }
}
