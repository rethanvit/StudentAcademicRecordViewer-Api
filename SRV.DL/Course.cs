using System.ComponentModel.DataAnnotations;

namespace SRV.DL
{
    public class Course
    {
        public int Id { get; set; }

        [StringLength(6)]
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool Active { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<OfferedCoursesInTerm> OfferedCoursesInTerms { get; set; }

    }
}
