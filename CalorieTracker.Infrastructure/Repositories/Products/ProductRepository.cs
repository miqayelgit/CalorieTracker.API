
using CalorieTracker.Application.Contracts;
using CalorieTracker.Domain.Entities.Product;
using Infrastructure.Context;

namespace CalorieTracker.Infrastructure.Repositories;

internal class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(DatabaseContext context) : base(context)
    {
    }
}
