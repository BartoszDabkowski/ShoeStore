using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeStore.Models;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Persistence.Interface;

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