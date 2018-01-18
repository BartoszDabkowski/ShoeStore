using Microsoft.EntityFrameworkCore;
using ShoeStore.Core.Models;

namespace ShoeStore.Persistence
{
    public class ShoeStoreDbContext : DbContext
    {
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<ShoeStyle> ShoeStyles { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

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

            modelBuilder.Entity<Inventory>()
                .HasOne(sh => sh.Shoe)
                .WithMany(i => i.Inventory)
                .HasForeignKey(sh => sh.ShoeId);

            modelBuilder.Entity<Inventory>()
                .HasOne(c => c.Color)
                .WithMany(i => i.Inventory)
                .HasForeignKey(c => c.ColorId);

            modelBuilder.Entity<Inventory>()
                .HasOne(s => s.Size)
                .WithMany(i => i.Inventory)
                .HasForeignKey(s => s.SizeId);
        }
    }
}