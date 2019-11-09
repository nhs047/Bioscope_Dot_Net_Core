using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class CountryService : ICountryService
  {
    private readonly ICountryRepository _countryRepository;
    public CountryService(ICountryRepository countryRepository) => _countryRepository = countryRepository;

    public void AddCountry(Country country) => _countryRepository.Add(country);

    public async Task<IEnumerable<Country>> GetAllCountries() => await _countryRepository.GetAll(x => x.Status != Status.Deleted);

    public async Task<Country> GetCountryById(long id) => await _countryRepository.GetById(id);

    public void RemoveCountry(Country country) => _countryRepository.Delete(country);

    public void UpdateCountry(long id, Country country) => _countryRepository.Update(country);
  }
}