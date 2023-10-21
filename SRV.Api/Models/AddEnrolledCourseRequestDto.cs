namespace SRV.Api.Models
{
    public class AddEnrolledCourseRequestDto
    {
        public int marks { get; set; }
        public string term { get; set; }
        public int courseId { get; set; }
        public int year { get; set; }

    }
}
