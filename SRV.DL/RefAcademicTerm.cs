namespace SRV.DL
{
    public class RefAcademicTerm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Terms { get; set; }
        public bool Active { get; set; }
        public List<Department> Departments { get; set; }
        public List<AcademicTermDetail> AcademicSystemDetails { get; set; }
    }
}
