using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class CityService : ICityService
  {
    private readonly ICityRepository _cityRepository;
    public CityService(ICityRepository cityRepository) => _cityRepository = cityRepository;

    public void AddCity(City City) => _cityRepository.Add(City);

    public async Task<IEnumerable<City>> GetAllCities() => await _cityRepository.GetAll(x => x.Status != Status.Deleted);

    public async Task<City> GetCityById(long id) => await _cityRepository.GetById(id);

    public void RemoveCity(City City) => _cityRepository.Delete(City);

    public void UpdateCity(long id, City City) => _cityRepository.Update(City);
  }
}