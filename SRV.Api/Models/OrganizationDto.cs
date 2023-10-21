namespace SRV.Api.Models
{
    public class OrganizationDto
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool Active { get; set; }
    }
}
