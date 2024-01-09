
using TodoApi.Models;
namespace TodoApi.Services;
public interface IProductService
{
    List<ProductDto> SearchProducts(string searchTerm);
}
