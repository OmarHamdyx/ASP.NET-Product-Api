
using ComApi.Models;
namespace ComApi.Services;
public interface IProductService
{
    List<ResponseDto> SearchProducts(string searchTerm);
}
