namespace SRV.DL
{
    public class RefAcademicTerm
    {
        public int AcademicTermId { get; set; }
        public string Name { get; set; }
        public int Terms { get; set; }
        public bool Active { get; set; }
        public List<AcademicCalendar> AcademicCalendars { get; set; }
        public List<Program> Programs { get; set; }
    }
}
