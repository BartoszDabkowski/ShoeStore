using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using ShoeStore.Core;
using ShoeStore.Core.Models;
using ShoeStore.Extensions;

namespace ShoeStore.Persistence
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly ShoeStoreDbContext _context;
        public ShoeRepository(ShoeStoreDbContext context)
        {
            _context = context;
        }

        public async Task<QueryResult<Shoe>> GetShoesAsync(ShoeQuery queryObj)
        {
            var result = new QueryResult<Shoe>();

            var query =  _context.Shoes.Where(s => !s.IsDeleted)
                .Select(s => new Shoe
                {
                    Id = s.Id,
                    Name = s.Name,
                    Brand = s.Brand,
                    BrandId = s.BrandId,
                    ShoeStyles = s.ShoeStyles.Select(ss => new ShoeStyle
                    {
                        StyleId = ss.StyleId,
                        Style = ss.Style
                    }).ToList(),
                    Inventory = s.Inventory.Select(i => new Inventory
                    {
                        Id = i.Id,
                        SizeId = i.SizeId,
                        Size = i.Size,
                        ColorId = i.ColorId,
                        Color = i.Color
                    }).ToList()
                }).AsQueryable();

            if (queryObj.BrandId.HasValue)
                query = query.Where(s => s.Brand.Id == queryObj.BrandId.Value);

            var columnsMap = new Dictionary<string, Expression<Func<Shoe, object>>>()
            {
                ["brandName"] = s => s.Brand.Name,
                ["shoeName"] = s => s.Name
            };

            query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();


            return result;

        }

        public async Task<Shoe> GetShoeAsync(int id, bool includeRelated = true)
        {
            if(!includeRelated)
                return await _context.Shoes.FindAsync(id);

            return await _context.Shoes
                .Include(s => s.Brand)
                .Include(s => s.Inventory).ThenInclude(i => i.Color)
                .Include(s => s.Inventory).ThenInclude(i => i.Size)
                .Include(s => s.ShoeStyles).ThenInclude(ss => ss.Style)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Add(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
        }
    }
}