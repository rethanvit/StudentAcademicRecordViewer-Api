namespace SRV.DL
{
    public class AcademicCalendarDetail
    {
        public int AcademicCalendarDetailId { get; set; }
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public AcademicCalendar RefAcademicCalendar { get; set; }
        public int AcademicCalendarId { get; set; }
        public List<OfferedCourse> OfferedCourses { get; set; }
        public List<Student> Students { get; set; }

    }
}
