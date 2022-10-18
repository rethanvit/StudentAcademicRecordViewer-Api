using AutoMapper;
using SRV.Api.Models;
using SRV.DL;

namespace SRV.Api.MappingProfiles
{
    public class EntityToDtoProfile:Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Student, StudentDtoForGet>();
            CreateMap<Student, StudentWithCoursesDtoGet>()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.FirstName, b => b.MapFrom(c => c.FirstName))
                .ForMember(a => a.LastName, b => b.MapFrom(c => c.LastName))
                .ForMember(a => a.EnrolledCourses, b => b.MapFrom((c,a) => {
                    var listOfEnrolledCourses = new List<EnrolledCourseDetailsDto>();
                    foreach (var enrolledCourse in c.EnrolledCourses)
                    {
                        listOfEnrolledCourses.Add(new EnrolledCourseDetailsDto
                        {
                            Code = enrolledCourse.OfferedCoursesInTerm.Course.Code,
                            Name = enrolledCourse.OfferedCoursesInTerm.Course.Name,
                            Department = enrolledCourse.OfferedCoursesInTerm.Course.Department.Name,
                            Marks = enrolledCourse.Marks,
                            AcademicTerm = enrolledCourse.OfferedCoursesInTerm.AcademicTermDetail.Term,
                            AcademicYear = enrolledCourse.OfferedCoursesInTerm.AcademicTermDetail.Year
                        });
                    }
                    return listOfEnrolledCourses;
                
                }));

        }
    }
}
