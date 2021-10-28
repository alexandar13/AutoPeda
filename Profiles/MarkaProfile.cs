using AutoMapper;
using AutoPeda.Dtos;
using AutoPeda.Models;

namespace AutoPeda.Profiles
{
    public class MarkaProfiles : Profile
    {
        public MarkaProfiles()
        {
            CreateMap<Marka, MarkaReadDto>();
        }
    }
}