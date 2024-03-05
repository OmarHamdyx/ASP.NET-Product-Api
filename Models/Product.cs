namespace ComApi.Models;

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public ICollection<ProductCategory>? ProductCategories { get; set; }
}
