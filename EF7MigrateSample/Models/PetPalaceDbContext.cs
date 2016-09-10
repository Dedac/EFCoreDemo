using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF7NavigationSample.Models
{
    public class PetPalaceDbContext : DbContext
    {
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreCustomer>(entity =>
            {
                entity.HasKey(sc => new { sc.CustomerId, sc.StoreId });
                entity.HasOne(sc => sc.Customer).WithMany(c => c.Stores).HasForeignKey(sc => sc.CustomerId);
                entity.HasOne(sc => sc.Store).WithMany(s => s.Customers).HasForeignKey(sc => sc.StoreId);
            });
        }
    }
}
