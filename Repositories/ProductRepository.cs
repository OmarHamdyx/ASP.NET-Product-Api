using ComApi.Data;
using ComApi.Interfaces;
using ComApi.Models;


namespace ComApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public List<ResponseDto> Search(string searchTerm)
    {


        if (searchTerm.Equals("all-products", StringComparison.OrdinalIgnoreCase))
        {
            List<ResponseDto> allProducts = _context.Products.Select(p => new ResponseDto()
            {
                ItemId = p.ProductId,
                ItemName = p.Name
            }).ToList();

            return allProducts; 

        }
        if (searchTerm.Equals("all-categories", StringComparison.OrdinalIgnoreCase))
        {
            List<ResponseDto> allProducts = _context.Categories.Select(c => new ResponseDto()
            {
                ItemId = c.CategoryId,
                ItemName = c.Name
            }).ToList();

            return allProducts; 

        }
        var matchingProducts = _context.Products
            .Where(p =>
                p.Name != null &&
                (p.Name.Contains(searchTerm) || (p.ProductCategories != null &&
                  p.ProductCategories.Any(pc => pc.Category != null && pc.Category.Name != null && pc.Category.Name.Contains(searchTerm)))))
            .Select(p => new ResponseDto
            {
                ItemId = p.ProductId,
                ItemName = p.Name
            })
            .ToList();

        return matchingProducts;
    }
}

