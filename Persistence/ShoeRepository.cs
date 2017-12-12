using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Models;

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
                .Include(s => s.Brand)
                .Include(s => s.ShoeStyles)
                    .ThenInclude(ss => ss.Style)
                .ToListAsync();
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

        public void Remove(Shoe shoe)
        {
            _context.Shoes.Remove(shoe);
        }
    }
}