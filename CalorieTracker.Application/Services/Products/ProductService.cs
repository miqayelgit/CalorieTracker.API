
using CalorieTracker.Application.Contracts.Repos.UOW;
using CalorieTracker.Domain.Entities.Product;
using CalorieTracker.Domain.Entities.User;
using CalorieTracker.Domain.Enums;
using CalorieTracker.Dtos.Product;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Application.Contracts.Services.Products;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;

    public ProductService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task AddProductAsync(Guid userId, ProductDto dto)
    {
        var entity = new Product
        {
            UserId = userId,
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

    public async Task<List<ProductDto>> GetProductsAsync(Guid userId)
    {
        var products = await _unitOfWork.ProductRepository
            .GetFromWhereAsync(p => p.UserId == userId || p.VisibilityScope == VisibilityScope.Public);

        return products
            .Select(product => new ProductDto
            {
                Name = product.ProductName,
                ProteinPerHundredGram = product.ProteinPerHundredGram,
                CarbsPerHundredGram = product.CarbsPerHundredGram,
                FatPerHundredGram = product.FatPerHundredGram,
                CaloriesPerHundredGram = product.CaloriesPerHundredGram
            }).ToList();
    }
}
