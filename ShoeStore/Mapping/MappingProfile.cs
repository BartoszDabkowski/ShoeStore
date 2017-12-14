using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ShoeStore.Controllers.Resources;
using ShoeStore.Models;
using ShoeStore.Persistence;

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
                .ForMember(sr => sr.Colors, opt => 
                    opt.MapFrom(s => s.Inventory
                        .GroupBy(i => i.ColorId)
                        .Select(g => g.First())
                        .Select(i => new KeyValuePairResource{ Id = i.Color.Id, Name = i.Color.Name})))
                .ForMember(sr => sr.Sizes, opt => 
                    opt.MapFrom(s => s.Inventory
                        .GroupBy(i => i.SizeId)
                        .Select(g => g.First())
                        .Select(i => new KeyValuePairResource{ Id = i.Size.Id, Name = i.Size.Name.ToString()})));

            CreateMap<Shoe, SaveShoeResource>()
                .ForMember(sur => sur.Styles, opt => opt.MapFrom(s => s.ShoeStyles.Select(sur => sur.StyleId)));

            // API to Domain Resource
            CreateMap<SaveShoeResource, Shoe>()
                .ForMember(s => s.ShoeStyles, opt => opt.Ignore())
                .ForMember(s => s.Inventory, opt => opt.Ignore())
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

                    foreach(var color in sur.Colors){
                        foreach(var size in sur.Sizes){
                            s.Inventory.Add(new Inventory{
                                ShoeId = s.Id,
                                ColorId = color,
                                SizeId = size
                            });
                        }
                    }
                });
        }
    }
}