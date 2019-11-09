using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
  public interface IFeatureRepository : IRepository<Feature>
  {

  }

  public class FeatureRepository : RepositoryBase<DataContext, Feature>, IFeatureRepository
  {
    public FeatureRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory) { }
  }
}