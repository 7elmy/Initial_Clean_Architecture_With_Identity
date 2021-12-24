using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Initial_Clean_Architecture_With_Identity.Domain.Interfaces;

public interface IRepositoryAsync<TEntity> where TEntity : class
{
    #region DQL
    ValueTask<TEntity> GetByIdAsync(object id);

    Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool disableTracking = true);

    IEnumerable<TEntity> GetListPaginate(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        int index = 0,
        int size = 10,
        bool disableTracking = true);

    IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool disableTracking = true);
    #endregion



    #region DML
    ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity);
    Task AddAsync(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Update(IEnumerable<TEntity> entities);
    void Remove(object id);
    void Remove(IEnumerable<object> ids);
    #endregion
}

