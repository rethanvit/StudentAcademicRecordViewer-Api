using AutoMapper;
using SRV.Api.Models;
using SRV.DL;

namespace SRV.Api.MappingProfiles
{
    public class DtoToEntityProfile: Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<StudentDtoForGet, Student>();
        }
    }
}
