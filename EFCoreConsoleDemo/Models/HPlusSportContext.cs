using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreConsoleDemo.Models
{
    public partial class HPlusSportContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HPlusSport;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasColumnType("varchar(50)");

                entity.Property(e => e.City).HasColumnType("varchar(50)");

                entity.Property(e => e.Email).HasColumnType("varchar(50)");

                entity.Property(e => e.FirstName).HasColumnType("varchar(50)");

                entity.Property(e => e.LastName).HasColumnType("varchar(50)");

                entity.Property(e => e.Phone).HasColumnType("varchar(50)");

                entity.Property(e => e.State).HasColumnType("varchar(50)");

                entity.Property(e => e.Zipcode).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.SalespersonId).HasColumnName("SalespersonID");

                entity.Property(e => e.Status).HasColumnType("varchar(50)");

                entity.Property(e => e.TotalDue).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.Salesperson)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.SalespersonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Order_Salesperson");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("ProductID")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_OrderItem_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_OrderItem_Product1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasMaxLength(10);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName).HasColumnType("varchar(50)");

                entity.Property(e => e.Status).HasColumnType("varchar(50)");

                entity.Property(e => e.Variety).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Salesperson>(entity =>
            {
                entity.Property(e => e.SalespersonId).HasColumnName("SalespersonID");

                entity.Property(e => e.Address).HasColumnType("varchar(50)");

                entity.Property(e => e.City).HasColumnType("varchar(50)");

                entity.Property(e => e.Email).HasColumnType("varchar(50)");

                entity.Property(e => e.FirstName).HasColumnType("varchar(50)");

                entity.Property(e => e.LastName).HasColumnType("varchar(50)");

                entity.Property(e => e.Phone).HasColumnType("varchar(50)");

                entity.Property(e => e.State).HasColumnType("varchar(50)");

                entity.Property(e => e.Zipcode).HasColumnType("varchar(50)");
            });
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Salesperson> Salesperson { get; set; }
    }
}