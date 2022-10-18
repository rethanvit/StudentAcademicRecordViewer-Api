namespace SRV.Api.Models
{
    public class StudentWithCoursesDtoGet
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IReadOnlyCollection<EnrolledCourseDetailsDto> EnrolledCourses { get; set; }

    }

    public class EnrolledCourseDetailsDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int AcademicYear { get; set; }
        public int AcademicTerm { get; set; }
        public double Marks { get; set; }

    }
}
