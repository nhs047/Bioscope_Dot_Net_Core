using Bioscope.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Bioscope.Infrastructure
{
  public class DbFactory<TContext> : Disposable, IDbFactory<TContext> where TContext : DbContext
  {
    private readonly TContext _dbContext;

    public DbFactory(TContext dbContext) => _dbContext = dbContext;
    public TContext Init() => _dbContext;
    protected override void DisposeCore() => _dbContext?.Dispose();
  }
}