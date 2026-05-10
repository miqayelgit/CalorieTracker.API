
using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Domain.Entities.Product;
using CalorieTracker.Domain.Enums;
using CalorieTracker.Dtos.Product;

namespace CalorieTracker.Application.Contracts.Services.Products;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddProduct(ProductDto dto)
    {
        var entity = new Product
        {
            UserId = dto.UserId,
            ProductName = dto.Name,
            ProteinPerHundredGram = dto.ProteinPerHundredGram,
            CarbsPerHundredGram = dto.CarbsPerHundredGram,
            FatPerHundredGram = dto.FatPerHundredGram,
            CaloriesPerHundredGram = dto.CaloriesPerHundredGram,
            VisibilityScope = VisibilityScope.Private
        };

        _unitOfWork.ProductRepository.Add(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<ProductDto>> GetProducts()
    {
        var products =  await _unitOfWork.ProductRepository.GetFromWhereAsync();

        return products
            .Select(product => new ProductDto
            { 
                Name = product.ProductName,
                ProteinPerHundredGram = product.ProteinPerHundredGram,
                CarbsPerHundredGram = product.CarbsPerHundredGram,
                FatPerHundredGram = product.FatPerHundredGram,
                CaloriesPerHundredGram = product.CaloriesPerHundredGram
            })
            .ToList();
    }
}
