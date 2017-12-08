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
                .ForMember(sr => sr.Styles, opt => opt.MapFrom(s => s.ShoeStyles.Select(ss => new KeyValuePairResource{ Id = ss.Style.Id, Name = ss.Style.Name})))
                .ForMember(sr => sr.Colors, opt => opt.MapFrom(s => s.ShoeColors.Select(sc => new KeyValuePairResource{ Id = sc.Color.Id, Name = sc.Color.Name})))
                .ForMember(sr => sr.Sizes, opt => opt.MapFrom(s => s.ShoeSizes.Select(sc => new KeyValuePairResource{ Id = sc.Size.Id, Name = sc.Size.Name.ToString()})));
            CreateMap<Shoe, SaveShoeResource>()
                .ForMember(sur => sur.Styles, opt => opt.MapFrom(s => s.ShoeStyles.Select(sur => sur.StyleId)))
                .ForMember(sur => sur.Colors, opt => opt.MapFrom(s => s.ShoeColors.Select(sur => sur.ColorId)))
                .ForMember(sur => sur.Sizes, opt => opt.MapFrom(s => s.ShoeSizes.Select(sur => sur.SizeId)));

            // API to Domain Resource
            CreateMap<SaveShoeResource, Shoe>()
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

                    // Remove unselected sizes
                    var removedSizes = s.ShoeSizes.Where(st => !sur.Sizes.Contains(st.SizeId)).ToList();
                    foreach(var ss in removedSizes)
                        s.ShoeSizes.Remove(ss);

                    // Add new sizes
                    var addedSizes = sur.Sizes.Where(id => !s.ShoeSizes.Any(st => st.SizeId == id))
                        .Select(id => new ShoeSize {SizeId = id});
                    foreach(var ss in addedSizes)
                        s.ShoeSizes.Add(ss);
                });
        }
    }
}