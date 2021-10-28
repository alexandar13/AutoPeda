using AutoMapper;
using AutoPeda.Dtos;
using AutoPeda.Models;

namespace AutoPeda.Profiles
{
    public class AutoProfiles : Profile
    {
        public AutoProfiles()
        {
            CreateMap<Auto, AutoReadDto>();
            CreateMap<AutoCreateDto, Auto>();
            CreateMap<AutoUpdateDto, Auto>();
            CreateMap<Auto, AutoUpdateDto>();
        }
    }
}