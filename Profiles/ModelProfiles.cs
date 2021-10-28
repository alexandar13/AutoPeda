using AutoMapper;
using AutoPeda.Dtos;
using AutoPeda.Models;

namespace AutoPeda.Profiles
{
    public class ModelProfiles : Profile
    {
        public ModelProfiles()
        {
            CreateMap<Model, ModelReadDto>();
            CreateMap<ModelCreateDto, Model>();
            CreateMap<ModelUpdateDto, Model>();
            CreateMap<Model, ModelUpdateDto>();
        }
    }
}