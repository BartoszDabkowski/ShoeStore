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
            CreateMap<Style, KeyValuePairResource>();
            CreateMap<Color, KeyValuePairResource>();
            CreateMap<Size, KeyValuePairResource>();
            CreateMap<Shoe, ShoeResource>()
                .ForMember(sr => sr.Brand, opt => opt.MapFrom(s => new KeyValuePairResource{ Id = s.Brand.Id, Name = s.Brand.Name}))
                .ForMember(sr => sr.Styles, opt => opt.MapFrom(s => s.Styles.Select(ss => new KeyValuePairResource{ Id = ss.Style.Id, Name = ss.Style.Name})))
                .ForMember(sr => sr.Colors, opt => opt.MapFrom(s => s.Colors.Select(sc => new KeyValuePairResource{ Id = sc.Color.Id, Name = sc.Color.Name})));
            CreateMap<Shoe, SaveShoeResource>()
                .ForMember(sur => sur.Styles, opt => opt.MapFrom(s => s.Styles.Select(sur => sur.StyleId)))
                .ForMember(sur => sur.Colors, opt => opt.MapFrom(s => s.Colors.Select(sur => sur.ColorId)));

            // API to Domain Resource
            CreateMap<SaveShoeResource, Shoe>()
                .ForMember(s => s.Styles, opt => opt.Ignore())
                .ForMember(s => s.Colors, opt => opt.Ignore())
                .AfterMap((sur, s) => {
                    // Remove unselected colors
                    var removedColors = s.Colors.Where(c => !sur.Colors.Contains(c.ColorId)).ToList();
                    foreach(var c in removedColors)
                        s.Colors.Remove(c);

                    // Add new colors
                    var addedColors = sur.Colors.Where(id => !s.Colors.Any(c => c.ColorId == id))
                        .Select(id => new ShoeColor {ColorId = id});
                    foreach(var c in addedColors)
                        s.Colors.Add(c);

                    // Remove unselected styles
                    var removedStyles = s.Styles.Where(st => !sur.Styles.Contains(st.StyleId)).ToList();
                    foreach(var st in removedStyles)
                        s.Styles.Remove(st);

                    // Add new styles
                    var addedStyles = sur.Styles.Where(id => !s.Styles.Any(st => st.StyleId == id))
                        .Select(id => new ShoeStyle {StyleId = id});
                    foreach(var st in addedStyles)
                        s.Styles.Add(st);
                });
        }
    }
}