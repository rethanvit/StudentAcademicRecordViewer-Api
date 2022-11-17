namespace SRV.Api.Models
{
    public class StudentDtoForGet
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Program { get; set; }
        public string Organization { get; set; }

    }
}