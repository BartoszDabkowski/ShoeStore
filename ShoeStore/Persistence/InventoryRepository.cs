using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ShoeStore.Core;
using ShoeStore.Core.Models;

namespace ShoeStore.Persistence
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ShoeStoreDbContext _context;
        public InventoryRepository(ShoeStoreDbContext context)
        {
            _context = context;
        }

        public void Add(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
        }
    }
}