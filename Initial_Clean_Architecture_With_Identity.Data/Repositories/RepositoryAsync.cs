using Initial_Clean_Architecture_With_Identity.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Initial_Clean_Architecture_With_Identity.Data.Repositories;

public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
{
    protected readonly DbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public RepositoryAsync(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    #region DQL
    public ValueTask<TEntity> GetByIdAsync(object id)
    {
        return _dbSet.FindAsync(id);
    }

    public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true)
    {
        IQueryable<TEntity> query = _dbSet;
        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (orderBy != null)
            return orderBy(query).FirstOrDefaultAsync();
        return query.FirstOrDefaultAsync();
    }

    public IEnumerable<TEntity> GetListPaginate(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int index = 0, int size = 10, bool disableTracking = true)
    {
        IQueryable<TEntity> query = _dbSet;
        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (orderBy != null)
            return orderBy(query).Skip(index).Take(size);
        return query.Skip(index).Take(size);
    }

    public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true)
    {
        IQueryable<TEntity> query = _dbSet;
        if (disableTracking) query = query.AsNoTracking();

        if (include != null) query = include(query);

        if (predicate != null) query = query.Where(predicate);

        if (orderBy != null)
            return orderBy(query).ToList();
        return query.ToList();
    }
    #endregion


    #region DML
    public ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity)
    {
        return _dbSet.AddAsync(entity);
    }
    public Task AddAsync(IEnumerable<TEntity> entities)
    {
        return _dbSet.AddRangeAsync(entities);
    }
    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }
    public void Update(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
    }
    public void Remove(object id)
    {
        var entity = _dbSet.Find(id);
        _dbSet.Remove(entity);
    }


    public void Remove(IEnumerable<object> ids)
    {
        foreach (var id in ids)
        {
            Remove(id);
        }
    }
    #endregion
}

