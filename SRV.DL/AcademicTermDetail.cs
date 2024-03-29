﻿namespace SRV.DL
{
    internal class AcademicTermDetail
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int? Term { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public bool Active { get; set; }
        public int RefAcademicTermId { get; set; }
        public RefAcademicTerm RefAcademicTerm { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
