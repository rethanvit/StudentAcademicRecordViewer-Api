using AutoMapper;
using SRV.Api.Models;
using SRV.DL;

namespace SRV.Api.MappingProfiles
{
    public class EntityToDtoProfile:Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Student, StudentWithCoursesDtoGet>()
                .ForMember(a => a.StudentId, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.FirstName, b => b.MapFrom(c => c.FirstName))
                .ForMember(a => a.LastName, b => b.MapFrom(c => c.LastName))
                .ForMember(a => a.CoursesEnrolled, b => b.MapFrom((c,a) => {
                    var listOfEnrolledCourses = new List<EnrolledCourseDetailsDto>();
                    foreach (var enrolledCourse in c.EnrolledCourses)
                    {
                        listOfEnrolledCourses.Add(new EnrolledCourseDetailsDto
                        {
                            Code = enrolledCourse.Course.Code,
                            Name = enrolledCourse.Course.Name,
                            Department = enrolledCourse.Course.Department.Name,
                            Marks = enrolledCourse.Marks,
                            AcademicTerm = enrolledCourse.AcademicCalendarDetail.RefAcademicCalendar.RefAcademicTerm.Name,
                            AcademicYear = enrolledCourse.AcademicCalendarDetail.Year
                        });
                    }
                    return listOfEnrolledCourses;
                
                }));

        }
    }
}
