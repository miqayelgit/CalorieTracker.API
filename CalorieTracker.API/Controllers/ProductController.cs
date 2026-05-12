using CalorieTracker.Application.Contracts.Services.Products;
using CalorieTracker.Dtos.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.API.Controllers;

[Authorize]
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
    public async Task<IActionResult> CreateAsync([FromBody] ProductDto dto)
    {
        await _productService.AddProduct(UserId, dto);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _productService.GetProductsAsync(UserId);
        return Ok(products);
    }
}
