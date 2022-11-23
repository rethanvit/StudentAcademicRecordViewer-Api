namespace SRV.DL
{
    public class OfferedCourse
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int AcademicCalendarDetailId { get; set; }
        public AcademicCalendarDetail AcademicCalendarDetail { get; set; }
        public List<EnrolledCourse> EnrolledCourses { get; set; }

    }
}
