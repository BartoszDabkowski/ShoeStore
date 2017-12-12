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
                .ForMember(sr => sr.Styles, opt => opt.MapFrom(s => s.ShoeStyles.Select(ss => new KeyValuePairResource{ Id = ss.Style.Id, Name = ss.Style.Name})));
            CreateMap<Shoe, SaveShoeResource>()
                .ForMember(sur => sur.Styles, opt => opt.MapFrom(s => s.ShoeStyles.Select(sur => sur.StyleId)));

            // API to Domain Resource
            CreateMap<SaveShoeResource, Shoe>()
                .ForMember(s => s.ShoeStyles, opt => opt.Ignore())
                .AfterMap((sur, s) => {
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