using CalorieTracker.Application.Contracts.Repos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CalorieTracker.Infrastructure.Repositories;

internal abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected DatabaseContext Context;
    public RepositoryBase(DatabaseContext context)
    {
        Context = context;
    }
    
    public void Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);  
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null)
    {
        if(expression == null)
        {
            return Context.Set<TEntity>().FirstOrDefaultAsync();
        }

        return Context.Set<TEntity>().FirstOrDefaultAsync(expression);
    }

    public Task<List<TEntity>> GetFromWhereAsync(Expression<Func<TEntity, bool>>? expression = null)
    {
        if (expression == null)
        {
            return Context.Set<TEntity>().ToListAsync();
        }

       return Context.Set<TEntity>().Where(expression).ToListAsync();
    }
}
