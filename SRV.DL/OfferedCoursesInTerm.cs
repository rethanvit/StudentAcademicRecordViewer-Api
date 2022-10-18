using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.DL
{
    public class OfferedCoursesInTerm
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int AcademicTermDetailId { get; set; }
        public AcademicTermDetail AcademicTermDetail { get; set; }
        public List<EnrolledCourse> EnrolledCourses { get; set; }

    }
}
