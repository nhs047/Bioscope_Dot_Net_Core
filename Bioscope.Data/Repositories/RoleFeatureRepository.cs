using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
  public interface IRoleFeatureRepository : IRepository<RoleFeature>
  {

  }

  public class RoleFeatureRepository : RepositoryBase<DataContext, RoleFeature>, IRoleFeatureRepository
  {
    public RoleFeatureRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory) { }
  }
}