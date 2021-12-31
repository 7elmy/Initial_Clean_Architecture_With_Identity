using Initial_Clean_Architecture_With_Identity.Data.Repositories;
using Initial_Clean_Architecture_With_Identity.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Initial_Clean_Architecture_With_Identity.Data.UnitOfWork;

public class UnitOfWork<TContext> : IUnitOfWork
       where TContext : DbContext, IDisposable
{
    private Dictionary<Type, object> _repositories;
    private readonly TContext _context;

    public UnitOfWork(TContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IRepositoryAsync<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        if (_repositories == null)
            _repositories = new Dictionary<Type, object>();

        var type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
            _repositories[type] = new RepositoryAsync<TEntity>(_context);
        return (IRepositoryAsync<TEntity>)_repositories[type];
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}

