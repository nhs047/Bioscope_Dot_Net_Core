using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface ICityService
  {
    Task<IEnumerable<City>> GetAllCities();
    Task<City> GetCityById(long id);
    void AddCity(City city);
    void UpdateCity(long id, City city);
    void RemoveCity(City city);
  }
}