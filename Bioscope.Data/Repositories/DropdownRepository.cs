using System.Linq;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
  public interface IDropdownRepository
  {
    IQueryable<TEntity> AsQueryable<TEntity>() where TEntity : class;
  }

  public class DropdownRepository : IDropdownRepository
  {
    private readonly IDbFactory<DataContext> _dbFactory;
    private readonly DataContext _dbContext;

    public DropdownRepository(IDbFactory<DataContext> dbFactory) 
    {
      _dbFactory =  dbFactory;
      _dbContext = _dbContext ?? _dbFactory.Init();
    }

    public IQueryable<TEntity> AsQueryable<TEntity>() where TEntity : class
    {
      return _dbContext.Set<TEntity>().AsQueryable();
    }
  }
}