namespace SRV.DL
{
    public class OfferedCourse
    {
        public int OfferedCourseId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int AcademicCalendarDetailId { get; set; }
        public AcademicCalendarDetail AcademicCalendarDetail { get; set; }
        public EnrolledCourse EnrolledCourse { get; set; }

    }
}
