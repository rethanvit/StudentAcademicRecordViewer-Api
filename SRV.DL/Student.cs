namespace SRV.DL
{
    internal class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
