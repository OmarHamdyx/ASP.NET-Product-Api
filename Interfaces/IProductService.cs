
using ComApi.Models;
namespace ComApi.Services;
public interface IProductService
{
    public List<ProductDto> SearchProducts(string searchTerm);
}
