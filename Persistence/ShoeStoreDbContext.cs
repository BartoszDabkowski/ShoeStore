using Microsoft.EntityFrameworkCore;
using ShoeStore.Models;

namespace ShoeStore.Persistence
{
    public class ShoeStoreDbContext : DbContext
    {
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public ShoeStoreDbContext(DbContextOptions<ShoeStoreDbContext> options) 
            : base(options)
        {   
        }
    }
}