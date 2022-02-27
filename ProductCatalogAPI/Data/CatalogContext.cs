using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogItem> Catalog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogType>(e =>
            {
                e.Property(t => t.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(t => t.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CatalogBrand>(e =>
            {
                e.Property(b => b.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(b => b.Brand)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }

    }
}
