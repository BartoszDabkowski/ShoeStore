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
            var shoes = await _context.Shoes
                .Include(s => s.Brand)
                .Include(s => s.Styles)
                    .ThenInclude(ss => ss.Style)
                .Include(s => s.Colors)
                    .ThenInclude(sc => sc.Color)
                .ToListAsync();

            return mapper.Map<List<Shoe>, List<ShoeResource>>(shoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoeAsync(int id)
        {
            var shoe = await _context.Shoes
                .Include(s => s.Styles)
                .Include(s => s.Colors)
                .SingleOrDefaultAsync(s => s.Id == id);

            if(shoe == null)
                return NotFound();

            return Ok(mapper.Map<Shoe, SaveShoeResource>(shoe));
        }

        [HttpPost]
        public async Task<IActionResult> PostShoesAsync([FromBody] SaveShoeResource shoeUploadResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var shoe = mapper.Map<SaveShoeResource, Shoe>(shoeUploadResource);

            _context.Shoes.Add(shoe);
            await _context.SaveChangesAsync();

            var result = mapper.Map<Shoe, SaveShoeResource>(shoe);
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShoesAsync(int id, [FromBody] SaveShoeResource shoeUploadResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var shoe = await _context.Shoes
                .Include(s => s.Styles)
                .Include(s => s.Colors)
                .SingleOrDefaultAsync(s => s.Id == id);

            if(shoe == null)
                return NotFound();

            mapper.Map<SaveShoeResource, Shoe>(shoeUploadResource, shoe);

            await _context.SaveChangesAsync();

            var result = mapper.Map<Shoe, SaveShoeResource>(shoe);
            
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoeAsync(int id){
            var shoe = await _context.Shoes.FindAsync(id);

            if(shoe == null)
                return NotFound();

            _context.Remove(shoe);
            await _context.SaveChangesAsync();

            return Ok(id);
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