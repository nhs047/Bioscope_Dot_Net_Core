using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{

  public interface ICountryRepository : IRepository<Country>
  {

  }
  public class CountryRepository : RepositoryBase<DataContext, Country>, ICountryRepository
  {
    public CountryRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory) { }
  }
}