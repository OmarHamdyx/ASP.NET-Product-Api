using System.Collections.ObjectModel;

namespace ComApi.Models;

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public IEnumerable<ProductCategory>? ProductCategory { get; set; } 
}
