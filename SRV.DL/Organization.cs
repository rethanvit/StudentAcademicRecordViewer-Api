namespace SRV.DL
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool Active { get; set; }
        public List<Department> Departments { get; set; }
        public List<Course> Courses { get; set; }

        public List<Student> Students { get; set; }

    }
}
