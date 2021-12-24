namespace Initial_Clean_Architecture_With_Identity.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepositoryAsync<TEntity> GetRepository<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync();
}

