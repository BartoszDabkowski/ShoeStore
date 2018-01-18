using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Core;
using ShoeStore.Core.Models;

namespace ShoeStore.Persistence
{
    public class ColorRepository : IColorRepository
    {
        private readonly ShoeStoreDbContext _context;
        public ColorRepository(ShoeStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Color>> GetColorsAsync()
        {
            return await _context.Colors.ToListAsync();
        }
    }
}