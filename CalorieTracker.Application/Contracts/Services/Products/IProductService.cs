
using CalorieTracker.Dtos.Product;

namespace CalorieTracker.Application.Contracts.Services.Products;

public interface IProductService
{
    Task AddProduct(ProductDto dtol);
    Task<List<ProductDto>> GetProducts();
}
