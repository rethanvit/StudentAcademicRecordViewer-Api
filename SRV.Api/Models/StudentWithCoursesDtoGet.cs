namespace SRV.Api.Models
{
    public class StudentWithCoursesDtoGet
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<EnrolledCourseDetailsDto> CoursesEnrolled { get; set; } = new List<EnrolledCourseDetailsDto>();

    }

    public class EnrolledCourseDetailsDto
    {
        public string CourseCode { get; set; }
        public int CourseLevel { get; set; }
        public string CourseName { get; set; }
        public string DepartmentName { get; set; }
        public int AcademicYear { get; set; }
        public string AcademicTerm { get; set; }
        public double Marks { get; set; }

    }
}
