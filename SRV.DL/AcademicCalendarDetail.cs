namespace SRV.DL
{
    public class AcademicCalendarDetail
    {
        public int AcademicCalendarDetailId { get; set; }
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public RefAcademicCalendar RefAcademicCalendar { get; set; }
        public int AcademicCalendarId { get; set; }
        public List<EnrolledCourse> EnrolledCourses { get; set; }
        public List<OfferedCourses> OfferedCourses { get; set; }

    }
}
