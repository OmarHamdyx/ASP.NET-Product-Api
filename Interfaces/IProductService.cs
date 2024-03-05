
using ComApi.Models;
namespace ComApi.Services;
public interface IProductService
{
    List<ProductDto> SearchProducts(string searchTerm);
}
