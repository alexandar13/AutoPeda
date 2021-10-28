using AutoMapper;
using AutoPeda.Dtos;
using AutoPeda.Models;

namespace AutoPeda.Profiles
{
    public class KorisnikProfiles : Profile
    {
        public KorisnikProfiles()
        {
            CreateMap<Korisnik, KorisnikReadDto>();
            CreateMap<KorisnikCreateDto, Korisnik>();
            CreateMap<KorisnikUpdateDto, Korisnik>();
            CreateMap<Korisnik, KorisnikUpdateDto>();
        }
    }
}