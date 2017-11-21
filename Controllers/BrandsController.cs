using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Models;
using ShoeStore.Persistence;

namespace ShoeStore.Controllers
{
    public class BrandsController : Controller
    {
        private readonly ShoeStoreDbContext _context;
        public BrandsController(ShoeStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet("api/brands")]
        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await _context.Brands.Include(b => b.Shoes).ToListAsync();
        }
    }
}