namespace SRV.Api.Models
{
    public class YearAndTerm
    {
        public int AcademicYear { get; set; }
        public List<string> AcademicTerms { get; set; }
    }

    public class CourseYearAndTerm
    {
        public int CourseId { get; set; }
        public List<YearAndTerm> YearAndTerms { get; set; }
    }
}
