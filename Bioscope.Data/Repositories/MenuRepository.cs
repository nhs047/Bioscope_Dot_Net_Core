using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
  public interface IMenuRepository : IRepository<Menu>
  {

  }
  public class MenuRepository : RepositoryBase<DataContext, Menu>, IMenuRepository
  {
    public MenuRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory) { }
  }
}