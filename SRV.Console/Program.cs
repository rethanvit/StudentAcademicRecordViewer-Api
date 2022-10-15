// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using SRV.DL;

Console.WriteLine("Hello, World!");


StudentContext dbContext = new StudentContext();
//dbContext.Database.EnsureDeleted();
dbContext.Database.EnsureCreated();
var students = dbContext.Students.Include(c => c.StudentCourses).Where(s => s.Id == 1).Single();
students.StudentCourses.Last().Marks = 50;
dbContext.SaveChanges();
