using System.ComponentModel.DataAnnotations;

namespace SRV.DL
{
    public class Course
    {
        public int CourseId { get; set; }

        [StringLength(6)]
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool Active { get; set; }
        public int ProgramId { get; set; }
        public Program Program { get; set; }
        public List<OfferedCourse> OfferedCourses { get; set; }
        public List<EnrolledCourse> EnrolledCourses { get; set; }

    }
}
