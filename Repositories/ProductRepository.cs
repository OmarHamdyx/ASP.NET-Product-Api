using ComApi.Data;
using ComApi.Interfaces;
using ComApi.Models;
using System.Linq;


namespace ComApi.Repositories;

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
            .Where(p =>
                p.Name != null &&
                (p.Name.Contains(searchTerm) ||
                 (p.ProductCategories != null &&
                  p.ProductCategories.Any(pc => pc.Category != null && pc.Category.Name != null && pc.Category.Name.Contains(searchTerm)))))
            .Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                ProductName = p.Name
            })
            .ToList();

        return matchingProducts;
    }
}

