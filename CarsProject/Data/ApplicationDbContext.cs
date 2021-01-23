using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ModelStructure;

namespace CarsProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasOne(tcm => tcm.Engine)
                .WithMany(t => t.Cars)
                .HasForeignKey(tcm => tcm.EngineId);

            modelBuilder.Entity<Car>()
              .HasOne(tcm => tcm.Fuel)
              .WithMany(t => t.Cars)
              .HasForeignKey(tcm => tcm.FuelId);

            modelBuilder.Entity<Car>()
              .HasOne(tcm => tcm.Brand)
              .WithMany(t => t.Cars)
              .HasForeignKey(tcm => tcm.BrandId);
        }
    }
}