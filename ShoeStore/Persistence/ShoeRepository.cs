using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Models;
using System.Linq;
using ShoeStore.Persistence.Interface;

namespace ShoeStore.Persistence
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly ShoeStoreDbContext _context;
        public ShoeRepository(ShoeStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shoe>> GetShoesAsync()
        {
            return await _context.Shoes
            .Select(s => new Shoe{
                Id = s.Id,
                Name = s.Name,
                Brand = s.Brand,
                BrandId = s.BrandId,
                ShoeStyles = s.ShoeStyles.Select(ss => new ShoeStyle{
                    StyleId = ss.StyleId,
                    Style = ss.Style
                }).ToList(),
                Inventory = s.Inventory.Select(i => new Inventory{
                    Id = i.Id,
                    SizeId = i.SizeId,
                    Size = i.Size,
                    ColorId = i.ColorId,
                    Color = i.Color
                }).ToList()
            }).ToListAsync();
        }

        public async Task<Shoe> GetShoeAsync(int id, bool includeRelated = true)
        {
            if(!includeRelated)
                return await _context.Shoes.FindAsync(id);

            return await _context.Shoes
                .Include(s => s.Brand)
                .Include(s => s.ShoeStyles)
                    .ThenInclude(ss => ss.Style)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Add(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
        }
    }
}