namespace SRV.Api.Services
{
    public class AcademicCalendarDetailOptionsDto
    {

        public int AcademicCalendarDetailId { get; set; }
        public int Year { get; set; }
        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = DateTime.Parse(value.ToString("yyyy-MM-dd"));
        }
        public string Term { get; set; }
    }
}
