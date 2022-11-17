namespace SRV.DL
{
    public class OfferedCourses
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int AcademicCalendarDetailId { get; set; }
        public AcademicCalendarDetail AcademicCalendarDetail { get; set; }

    }
}
