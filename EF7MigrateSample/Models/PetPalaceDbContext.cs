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
            
        }
    }
}
