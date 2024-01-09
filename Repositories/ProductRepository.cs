using TodoApi.Data;
using TodoApi.Interfaces;
using TodoApi.Models;


namespace TodoApi.Repositories;

    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public List<ProductDto> Search(string searchTerm)
    {
        var matchingProducts = _context.Products
            .Where(p => p.Name.Contains(searchTerm) || p.ProductCategories.Any(pc => pc.Category.Name.Contains(searchTerm)))
            .Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                ProductName = p.Name
            })
            .ToList();

        return matchingProducts;
    }
    }

