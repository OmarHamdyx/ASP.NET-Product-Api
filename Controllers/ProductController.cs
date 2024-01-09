using Microsoft.AspNetCore.Mvc;
using TodoApi.Services;

//api/Product
// ProductController.cs
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{productName}")]
    public IActionResult GetProductByName(string productName)
    {
        var matchingProducts = _productService.SearchProducts(productName);

        if (matchingProducts.Count == 0)
        {
            return NotFound();
        }

        return Ok(matchingProducts);
    }
}

