using CalorieTracker.Application.Contracts.Services.Products;
using CalorieTracker.Dtos.Product;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : BaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto dto)
    {
        await _productService.AddProduct(dto);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _productService.GetProducts();
        return Ok(products);
    }
}
