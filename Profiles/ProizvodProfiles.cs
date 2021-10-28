using AutoMapper;
using AutoPeda.Dtos;
using AutoPeda.Models;

namespace AutoPeda.Profiles
{
    public class ProizvodProfiles : Profile
    {
        public ProizvodProfiles()
        {
            CreateMap<Proizvod, ProizvodReadDto>();
            CreateMap<ProizvodCreateDto, Proizvod>();
            CreateMap<ProizvodUpdateDto, Proizvod>();
            CreateMap<Proizvod, ProizvodUpdateDto>();
        }
    }
}