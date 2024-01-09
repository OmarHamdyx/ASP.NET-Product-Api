
using TodoApi.Models;
using TodoApi.Interfaces;
namespace TodoApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<ProductDto> SearchProducts(string searchTerm)
    {
        var matchingProducts = _productRepository.Search(searchTerm);

        return matchingProducts;
    }
}
