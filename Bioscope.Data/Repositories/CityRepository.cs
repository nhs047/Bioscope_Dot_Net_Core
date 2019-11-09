using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
  public interface ICityRepository : IRepository<City>
  {

  }
  public class CityRepository : RepositoryBase<DataContext, City>, ICityRepository
  {
    public CityRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory) { }
  }

}