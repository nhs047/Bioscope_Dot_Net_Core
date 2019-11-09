using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bioscope.App.Dtos;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Bioscope.Infrastructure;
using Bioscope.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Bioscope.App.API
{
  [Route("api/[controller]")]
  [ApiController]
  public class CountriesController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICountryService _countryService;

    public CountriesController(ICountryService countryService, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _countryService = countryService;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCountries()
    {
      try
      {
        var countries = await _countryService.GetAllCountries();
        var mappedCountries = _mapper.Map<IEnumerable<CountryDto>>(countries);
        return Ok(mappedCountries);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    public async Task<IActionResult> GetCountryById(long? id)
    {
      try
      {
        if (id == null) return BadRequest();
        var country = await _countryService.GetCountryById((long) id);
        var mappedCountry = _mapper.Map<SubscriptionDto>(country);
        return Ok(mappedCountry);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> AddSubscription(CountryDto countryDto)
    {
      try
      {
        var country = _mapper.Map<Country>(countryDto);
        _countryService.AddCountry(country);
        await _unitOfWork.Save();
        return Ok(country);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{countryId}")]
    public async Task<IActionResult> UpdateCountryById(long countryId, CountryDto countryDto)
    {
      try
      {
        if (countryId != countryDto.Id) return BadRequest();
        var country = await _countryService.GetCountryById(countryId);
        if (country == null) return NotFound();
        _mapper.Map(countryDto, country);
        _countryService.UpdateCountry(countryId, country);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{countryId}")]
    public async Task<IActionResult> DeleteCountryById(long countryId)
    {
      try
      {
        var country = await _countryService.GetCountryById(countryId);
        if (country == null) return NotFound();
        // not an actual delete
        country.Status = Status.Deleted;
        _countryService.UpdateCountry(countryId, country);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}