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
    [Route("api/shoes")]    
    public class ShoesController : Controller
    {
        private readonly ShoeStoreDbContext _context;
        private readonly IMapper mapper;
        public ShoesController(ShoeStoreDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ShoeResource>> GetShoesAsync()
        {
            var shoes = await _context.Shoes.ToListAsync();

            return mapper.Map<List<Shoe>, List<ShoeResource>>(shoes);
        }

        [HttpPost]
        public IActionResult PostShoes([FromBody] ShoeUploadResource shoeUploadResource)
        {
            var shoe = mapper.Map<ShoeUploadResource, Shoe>(shoeUploadResource);

            _context.Shoes.Add(shoe);
            
            return Ok();
        }

        [HttpGet("styles")]
        public async Task<IEnumerable<KeyValuePairResource>> GetStylesAsync()
        {
            var styles = await _context.Styles.ToListAsync();

            return mapper.Map<List<Style>,List<KeyValuePairResource>>(styles);
        }

        [HttpGet("colors")]
        public async Task<IEnumerable<KeyValuePairResource>> GetColorsAsync()
        {
            var colors = await _context.Colors.ToListAsync();

            return mapper.Map<List<Color>,List<KeyValuePairResource>>(colors);
        }

        [HttpGet("sizes")]
        public async Task<IEnumerable<KeyValuePairResource>> GetSizesAsync()
        {
            var sizes = await _context.Sizes.ToListAsync();

            return mapper.Map<List<Size>,List<KeyValuePairResource>>(sizes);
        }
    }
}