// Models/IProductRepository.cs
namespace TodoApi.Interfaces;
using TodoApi.Models;


public interface IProductRepository
{
 public List<ProductDto> Search(string searchTerm) ;  
}
