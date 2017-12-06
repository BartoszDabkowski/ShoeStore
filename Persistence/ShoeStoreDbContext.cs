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
        public DbSet<Color> Colors { get; set; }
        public DbSet<ShoeColor> ShoeColor { get; set; }
        public DbSet<Size> Sizes { get; set; }

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
                .WithMany(ss => ss.Styles)
                .HasForeignKey(sh => sh.ShoeId);

            modelBuilder.Entity<ShoeStyle>()
                .HasOne(st => st.Style)
                .WithMany(ss => ss.ShoeStyles)
                .HasForeignKey(st => st.StyleId);

            modelBuilder.Entity<ShoeColor>().HasKey(sc => 
              new { sc.ShoeId, sc.ColorId });

            modelBuilder.Entity<ShoeColor>()
                .HasOne(s => s.Shoe)
                .WithMany(sc => sc.Colors)
                .HasForeignKey(s => s.ShoeId);

            modelBuilder.Entity<ShoeColor>()
                .HasOne(c => c.Color)
                .WithMany(sc => sc.ShoeColors)
                .HasForeignKey(c =>c.ColorId);
        }
    }
}