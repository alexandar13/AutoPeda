using AutoMapper;
using AutoPeda.Dtos;
using AutoPeda.Models;

namespace AutoPeda.Profiles
{
    public class MotorProfiles : Profile
    {
        public MotorProfiles()
        {
            CreateMap<Motor, MotorReadDto>();
            CreateMap<MotorCreateDto, Motor>();
            CreateMap<MotorUpdateDto, Motor>();
            CreateMap<Motor, MotorUpdateDto>();
        }
    }
}