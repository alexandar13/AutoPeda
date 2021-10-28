using AutoMapper;
using AutoPeda.Dtos;
using AutoPeda.Models;

namespace AutoPeda.Profiles
{
    public class NarudzbinaProfiles : Profile
    {
        public NarudzbinaProfiles()
        {
            CreateMap<Narudzbina, NarudzbinaReadDto>();
            CreateMap<NarudzbinaCreateDto, Narudzbina>();
        }
    }
}