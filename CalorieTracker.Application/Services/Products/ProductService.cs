
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

    public async Task AddProduct(ProductDto dto)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
        if (user == null)
        {
            return;
        }

        var visibilityScope = user.Roles.Any(x => x.Name == "Admin") ? VisibilityScope.Public : VisibilityScope.Private;

        var entity = new Product
        {
            UserId = dto.UserId,
            ProductName = dto.Name,
            ProteinPerHundredGram = dto.ProteinPerHundredGram,
            CarbsPerHundredGram = dto.CarbsPerHundredGram,
            FatPerHundredGram = dto.FatPerHundredGram,
            CaloriesPerHundredGram = dto.CaloriesPerHundredGram,
            VisibilityScope = visibilityScope
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
