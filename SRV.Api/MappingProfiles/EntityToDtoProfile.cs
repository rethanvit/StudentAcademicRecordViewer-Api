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
        }
    }
}
