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
    public class StylesController : Controller
    {
        private readonly ShoeStoreDbContext _context;
        private readonly IMapper mapper;
        public StylesController(ShoeStoreDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            _context = context;
        }

        [HttpGet("api/styles")]
        public async Task<IEnumerable<KeyValuePairResource>> GetBrandsAsync()
        {
            var styles = await _context.Styles.ToListAsync();

            return mapper.Map<List<Style>,List<KeyValuePairResource>>(styles);
        }
    }
}