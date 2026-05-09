
using System.Linq.Expressions;

namespace CalorieTracker.Application.Contracts.Repos;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    Task<List<TEntity>> GetFromWhereAsync(Expression<Func<TEntity, bool>>? expression = null);
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null);
}
