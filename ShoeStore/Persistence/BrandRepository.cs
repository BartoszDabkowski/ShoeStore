using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeStore.Models;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Persistence.Interface;

namespace ShoeStore.Persistence
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ShoeStoreDbContext _context;
        public BrandRepository(ShoeStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await _context.Brands
            .Include(b => b.Shoes)
            .ToListAsync();
        }
    }
}