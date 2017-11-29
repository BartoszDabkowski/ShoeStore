using Microsoft.EntityFrameworkCore;
using ShoeStore.Models;

namespace ShoeStore.Persistence
{
    public class ShoeStoreDbContext : DbContext
    {
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<ShoeStyle> ShoeStyles { get; set; }

        public ShoeStoreDbContext(DbContextOptions<ShoeStoreDbContext> options) 
            : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<ShoeStyle>().HasKey(ss => 
              new { ss.ShoeId, ss.StyleId });

            modelBuilder.Entity<ShoeStyle>()
                .HasOne(sh => sh.Shoe)
                .WithMany(ss => ss.ShoeStyles)
                .HasForeignKey(sh => sh.ShoeId);

            modelBuilder.Entity<ShoeStyle>()
                .HasOne(st => st.Style)
                .WithMany(ss => ss.ShoeStyles)
                .HasForeignKey(st => st.StyleId);
        }
    }
}