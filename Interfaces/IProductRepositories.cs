// Models/IProductRepository.cs
namespace ComApi.Interfaces;
using ComApi.Models;


public interface IProductRepository
{
    public  List<ResponseDto> Search(string searchTerm);
}
