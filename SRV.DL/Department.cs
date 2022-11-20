using System.ComponentModel.DataAnnotations;

namespace SRV.DL
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [StringLength(6)]
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public int MaxMarks { get; set; }
        public int MinMarks { get; set; }
        public bool Active { get; set; }
        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
        public List<Program> Programs { get; set; }
    }
}
