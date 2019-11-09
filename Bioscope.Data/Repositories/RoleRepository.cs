using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
  public interface IRoleRepository : IRepository<Role>
  {

  }
  
  public class RoleRepository : RepositoryBase<DataContext, Role>, IRoleRepository
  {
    public RoleRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory) { }
  }
}