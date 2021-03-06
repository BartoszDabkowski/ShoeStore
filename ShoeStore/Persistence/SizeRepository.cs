using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Core;
using ShoeStore.Core.Models;

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