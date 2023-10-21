namespace SRV.Api.Models
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Level { get; set; }
        public List<YearAndTerm> YearAndTerms { get; set; }
    }
}
