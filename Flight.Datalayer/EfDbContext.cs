using Flight.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flight.DataLayer
{
    public class EfDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Flight.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}