using JBD.DATA;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JBD.Service.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    public readonly ApplicationDbContext Context;
    public BaseRepository(ApplicationDbContext context)
    {
        Context = context;
    }
    protected virtual IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string? includeProperties = null, int? skip = null, int? take = null)
    {
        includeProperties = includeProperties ?? string.Empty;
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }

        return query;
    }

    public async Task<List<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
    {
        return await GetQueryable(filter, orderBy, includeProperties, skip, take).ToListAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await Context.Set<TEntity>().AnyAsync(filter);
    }
}