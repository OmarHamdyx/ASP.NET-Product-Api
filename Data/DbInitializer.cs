namespace TodoApi.Data;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
public class DbInitializer
{
    private readonly ModelBuilder modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        modelBuilder.Entity<Product>().HasData(
        new Product { ProductId = 1, Name = "Hp Laptop 15" },
        new Product { ProductId = 2, Name = "iPhone 15" },
        new Product { ProductId = 3, Name = "Samsung S23" },
        new Product { ProductId = 4, Name = "Samsung LED Screen 32" }
    );

        // Seed categories
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Laptops" },
            new Category { CategoryId = 2, Name = "Computers" },
            new Category { CategoryId = 3, Name = "Electronics" },
            new Category { CategoryId = 4, Name = "HP" },
            new Category { CategoryId = 5, Name = "Mobiles" },
            new Category { CategoryId = 6, Name = "Apple" },
            new Category { CategoryId = 7, Name = "Samsung" },
            new Category { CategoryId = 8, Name = "TVs" }
        );

        // Seed the ProductCategory relationships
        modelBuilder.Entity<ProductCategory>().HasData(
            new ProductCategory { ProductId = 1, CategoryId = 1 },
            new ProductCategory { ProductId = 1, CategoryId = 2 },
            new ProductCategory { ProductId = 1, CategoryId = 3 },
            new ProductCategory { ProductId = 1, CategoryId = 4 },
            new ProductCategory { ProductId = 2, CategoryId = 5 },
            new ProductCategory { ProductId = 2, CategoryId = 3 },
            new ProductCategory { ProductId = 2, CategoryId = 6 },
            new ProductCategory { ProductId = 3, CategoryId = 5 },
            new ProductCategory { ProductId = 3, CategoryId = 3 },
            new ProductCategory { ProductId = 3, CategoryId = 7 },
            new ProductCategory { ProductId = 4, CategoryId = 8 },
            new ProductCategory { ProductId = 4, CategoryId = 3 },
            new ProductCategory { ProductId = 4, CategoryId = 7 }
        );

    }
}
