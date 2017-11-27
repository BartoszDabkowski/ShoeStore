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
    public class ShoesController : Controller
    {
        private readonly ShoeStoreDbContext _context;
        private readonly IMapper mapper;
        public ShoesController(ShoeStoreDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            _context = context;
        }

        [HttpGet("api/shoes")]
        public async Task<IEnumerable<ShoeResource>> GetBrandsAsync()
        {
            var shoes = await _context.Shoes.ToListAsync();

            return mapper.Map<List<Shoe>,List<ShoeResource>>(shoes);
        }
    }
}