namespace ComApi.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public IEnumerable<ProductCategory>? ProductCategories { get; set; }
}
