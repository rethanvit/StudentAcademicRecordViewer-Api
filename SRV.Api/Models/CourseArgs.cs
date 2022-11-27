namespace SRV.Api.Models
{
    public class CourseArgs
    {
        public string CourseCode { get; set; }
        public int CourseLevel { get; set; }
        public int AcademicYear { get; set; }
        public string AcademicTerm { get; set; }
    }

    public class UpdateCourseArgs
    {
        public CurrentAndNewCourseDetails updateCourseArgs { get; set; }
    }
    public class CurrentAndNewCourseDetails
    {
        public string CourseCode { get; set; }
        public int CourseLevel { get; set; }
        public string CurrentAcademicTerm { get; set; }
        public int CurrentAcademicYear { get; set; }
        public int CurrentMarks { get; set; }
        public string UpdatedAcademicTerm { get; set; }
        public int UpdatedAcademicYear { get; set; }
        public int UpdatedMarks { get; set; }
    }
}
