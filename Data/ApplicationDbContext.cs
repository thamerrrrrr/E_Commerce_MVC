using E_Commerce_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace E_Commerce_MVC.Data
{
    public class ApplicationDbContext :DbContext
    {
   
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=E_Commerce_MVC;Trusted_Connection=True;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Mobiles" },
                new Category() { Id = 2, Name = "Laptops" },
                new Category() { Id = 3, Name = "Tablets" },
                new Category() { Id = 4, Name = "Cameras" },
                new Category() { Id = 5, Name = "Accessories" }




                );
        }
    }
}
