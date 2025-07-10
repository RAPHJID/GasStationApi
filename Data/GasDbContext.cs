using Microsoft.EntityFrameworkCore;
using GasStationApi.Models;

namespace GasStationApi.Data
{
    public class GasDbContext : DbContext
    {
        public GasDbContext(DbContextOptions<GasDbContext> options) : base(options)
        {
        }

        public DbSet<Cylinder> Cylinders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Customer)
                .WithMany()
                .HasForeignKey(t => t.CustomerId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Cylinder)
                .WithMany()
                .HasForeignKey(t => t.CylinderId);
        }
    }
}
