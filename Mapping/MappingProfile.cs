using System.Collections.Generic;
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
            CreateMap<Shoe, ShoeUploadResource>()
                .ForMember(sur => sur.Styles, opt => opt.MapFrom(s => s.ShoeStyles.Select(sur => sur.StyleId)))
                .ForMember(sur => sur.Colors, opt => opt.MapFrom(s => s.ShoeColors.Select(sur => sur.ColorId)));

            // API to Domain Resource
            CreateMap<ShoeUploadResource, Shoe>()
                .ForMember(s => s.ShoeStyles, opt => opt.Ignore())
                .ForMember(s => s.ShoeColors, opt => opt.Ignore())
                .AfterMap((sur, s) => {
                    // Remove unselected colors
                    var removedColors = s.ShoeColors.Where(c => !sur.Colors.Contains(c.ColorId)).ToList();
                    foreach(var c in removedColors)
                        s.ShoeColors.Remove(c);

                    // Add new colors
                    var addedColors = sur.Colors.Where(id => !s.ShoeColors.Any(c => c.ColorId == id))
                        .Select(id => new ShoeColor {ColorId = id});
                    foreach(var c in addedColors)
                        s.ShoeColors.Add(c);

                    // Remove unselected styles
                    var removedStyles = s.ShoeStyles.Where(st => !sur.Styles.Contains(st.StyleId)).ToList();
                    foreach(var st in removedStyles)
                        s.ShoeStyles.Remove(st);

                    // Add new styles
                    var addedStyles = sur.Styles.Where(id => !s.ShoeStyles.Any(st => st.StyleId == id))
                        .Select(id => new ShoeStyle {StyleId = id});
                    foreach(var st in addedStyles)
                        s.ShoeStyles.Add(st);
                });
        }
    }
}