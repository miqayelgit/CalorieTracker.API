
using System.Linq.Expressions;

namespace CalorieTracker.Application.Contracts;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    public void Add(TEntity entity);
    public void Delete(TEntity entity);
    public void Update(TEntity entity);
    public Task<List<TEntity>> GetFromWhereAsync(Expression<Func<TEntity, bool>>? expression = null);
    public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null);
    public Task<int> CommitAsync();
}
