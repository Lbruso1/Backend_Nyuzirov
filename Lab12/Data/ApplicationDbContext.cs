using Microsoft.EntityFrameworkCore;
using Lab12.Models;

namespace Lab12.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 999.99m,
                    Description = "High-performance laptop",
                    CreatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 2,
                    Name = "Smartphone",
                    Price = 499.99m,
                    Description = "Latest model smartphone",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
} 