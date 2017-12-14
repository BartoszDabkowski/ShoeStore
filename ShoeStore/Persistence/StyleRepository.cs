using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ShoeStore.Persistence
{
    public class StyleRepository : IStyleRepository
    {
        private readonly ShoeStoreDbContext _context;
        public StyleRepository(ShoeStoreDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Style>> GetStylesAsync()
        {
            return await _context.Styles.ToListAsync();
        }
    }
}