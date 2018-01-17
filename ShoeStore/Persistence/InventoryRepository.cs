using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Models;
using System.Linq;
using ShoeStore.Persistence.Interface;

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