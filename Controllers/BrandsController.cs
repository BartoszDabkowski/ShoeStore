using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Controllers.Resources;
using ShoeStore.Models;
using ShoeStore.Persistence;

namespace ShoeStore.Controllers
{
    public class BrandsController : Controller
    {
        private readonly ShoeStoreDbContext _context;
        private readonly IMapper mapper;
        public BrandsController(ShoeStoreDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            _context = context;
        }

        [HttpGet("api/brands")]
        public async Task<IEnumerable<BrandResource>> GetBrandsAsync()
        {
            var brands = await _context.Brands.Include(b => b.Shoes).ToListAsync();

            return mapper.Map<List<Brand>,List<BrandResource>>(brands);
        }
    }
}