using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bioscope.Infrastructure
{
  public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
  {
    private readonly IDbFactory<TContext> _dbFactory;
    private TContext _dbContext;
    public UnitOfWork(IDbFactory<TContext> dbFactory) => _dbFactory = dbFactory;
    public TContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());
    public IEntityTransaction BeginTransaction() => new EntityTransaction<TContext>(_dbContext ?? _dbFactory.Init());
    public async Task<int> Save() => await DbContext.SaveChangesAsync();
  }
}