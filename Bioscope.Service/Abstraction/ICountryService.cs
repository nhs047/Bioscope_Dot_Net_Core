using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface ICountryService
  {
    Task<IEnumerable<Country>> GetAllCountries();
    Task<Country> GetCountryById(long id);
    void AddCountry(Country country);
    void UpdateCountry(long id, Country country);
    void RemoveCountry(Country country);
  }
}