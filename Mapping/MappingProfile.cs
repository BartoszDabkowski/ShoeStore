using AutoMapper;
using ShoeStore.Controllers.Resources;
using ShoeStore.Models;

namespace ShoeStore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandResource>();
            CreateMap<Shoe, ShoeResource>();
        }
    }
}