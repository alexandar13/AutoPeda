using AutoMapper;
using AutoPeda.Dtos;
using AutoPeda.Models;

namespace AutoPeda.Profiles
{
    public class PotkategorijaProfiles : Profile
    {
        public PotkategorijaProfiles()
        {
            CreateMap<PotkategorijaProizvoda, PotkategorijaDto>();
        }
    }
}