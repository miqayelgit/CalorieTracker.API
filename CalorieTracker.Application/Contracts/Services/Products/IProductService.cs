
using CalorieTracker.Dtos.Products;

namespace CalorieTracker.Application.Contracts.Services.Products;

public interface IProductService
{
    Task AddProductAsync(Guid userId, ProductDto dto);
    Task<List<ProductDto>> GetProductsAsync(Guid userId);
}
