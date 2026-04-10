using CalorieTracker.Application.Contracts.Repos.Products;
using CalorieTracker.Domain.Entities.Product;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories.Products;

internal class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(DatabaseContext context) : base(context)
    {
    }
}
