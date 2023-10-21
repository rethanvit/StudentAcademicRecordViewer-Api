namespace SRV.DL
{
    public class Program
    {
        public int ProgramId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public bool Active { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
        public RefAcademicTerm RefAcademicTerm { get; set; }
        public int AcademicTermId { get; set; }
        public List<User> Users { get; set; }


    }
}
