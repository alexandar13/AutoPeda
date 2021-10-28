using AutoMapper;
using AutoPeda.Dtos;
using AutoPeda.Models;

namespace AutoPeda.Profiles
{
    public class AutoMotorProfiles : Profile
    {
        public AutoMotorProfiles()
        {
            CreateMap<AutoMotor, AutoMotorReadDto>();
        }
    }
}