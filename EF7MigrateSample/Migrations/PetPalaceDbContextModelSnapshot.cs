using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EF7NavigationSample.Models;

namespace EF7MigrateSample.Migrations
{
    [DbContext(typeof(PetPalaceDbContext))]
    partial class PetPalaceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF7NavigationSample.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("EF7NavigationSample.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int?>("StoreId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("EF7NavigationSample.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerId");

                    b.Property<string>("Name");

                    b.Property<int?>("OrderId");

                    b.Property<int>("PetType");

                    b.Property<decimal>("Price");

                    b.Property<int?>("StoreId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("EF7NavigationSample.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("EF7NavigationSample.Models.Order", b =>
                {
                    b.HasOne("EF7NavigationSample.Models.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("EF7NavigationSample.Models.Store")
                        .WithMany()
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("EF7NavigationSample.Models.Pet", b =>
                {
                    b.HasOne("EF7NavigationSample.Models.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("EF7NavigationSample.Models.Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("EF7NavigationSample.Models.Store")
                        .WithMany()
                        .HasForeignKey("StoreId");
                });
        }
    }
}
