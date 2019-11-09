using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bioscope.Infrastructure
{
  public class EntityTransaction<TContext> : IEntityTransaction where TContext : DbContext
  {
    private readonly IDbContextTransaction _transaction;
    public EntityTransaction(TContext dbContext) => _transaction = dbContext.Database.BeginTransaction();
    public void Commit() => _transaction.Commit();
    public void Rollback() => _transaction.Rollback();
    public void Dispose() => _transaction.Dispose();
  }
}