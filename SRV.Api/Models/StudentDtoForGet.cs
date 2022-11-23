namespace SRV.Api.Models
{
    public class StudentDtoForGet
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string ProgramName { get; set; }
        public string ProgramCode { get; set; }
        public string OrganizationName { get; set; }

    }
}