using System.Linq;
using AutoMapper;
using ShoeStore.Controllers.Resources;
using ShoeStore.Models;

namespace ShoeStore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Brand, BrandResource>();
            CreateMap<Shoe, ShoeResource>();
            CreateMap<Style, KeyValuePairResource>();
            CreateMap<Color, KeyValuePairResource>();
            CreateMap<Size, KeyValuePairResource>();

            // API to Domain Resource
            CreateMap<ShoeUploadResource, Shoe>()
                .ForMember(s => s.ShoeStyles, opt => opt.MapFrom(sur => sur.Styles.Select(id => new ShoeStyle {ShoeId = id})))
                .ForMember(s => s.ShoeColors, opt => opt.MapFrom(sur => sur.Colors.Select(id => new ShoeColor {ColorId = id})));
        }
    }
}