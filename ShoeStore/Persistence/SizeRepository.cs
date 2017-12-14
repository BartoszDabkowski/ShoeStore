using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ShoeStore.Persistence
{
    public class SizeRepository : ISizeRepository
    {
        private readonly ShoeStoreDbContext _context;
        public SizeRepository(ShoeStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Size>> GetSizesAsync()
        {
            return await _context.Sizes.ToListAsync();
        }
    }
}