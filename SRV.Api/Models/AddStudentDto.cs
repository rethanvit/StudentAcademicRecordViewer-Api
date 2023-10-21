namespace SRV.Api.Models
{
    public class AddStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProgramId { get; set; }
        public int AcademicDetailsStartId { get; set; }
    }
}
