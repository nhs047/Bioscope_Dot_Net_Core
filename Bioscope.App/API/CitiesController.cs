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
  public class CitiesController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICityService _cityService;

    public CitiesController(ICityService cityService, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _cityService = cityService;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCities()
    {
      try
      {
        var cities = await _cityService.GetAllCities();
        var mappedcities = _mapper.Map<IEnumerable<CityDto>>(cities);
        return Ok(mappedcities);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    public async Task<IActionResult> GetCityById(long? id)
    {
      try
      {
        if (id == null) return BadRequest();
        var city = await _cityService.GetCityById((long) id);
        var mappedCity = _mapper.Map<SubscriptionDto>(city);
        return Ok(mappedCity);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> AddSubscription(CityDto cityDto)
    {
      try
      {
        var city = _mapper.Map<City>(cityDto);
        _cityService.AddCity(city);
        await _unitOfWork.Save();
        return Ok(city);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{cityId}")]
    public async Task<IActionResult> UpdateCityById(long cityId, CityDto cityDto)
    {
      try
      {
        if (cityId != cityDto.Id) return BadRequest();
        var city = await _cityService.GetCityById(cityId);
        if (city == null) return NotFound();
        _mapper.Map(cityDto, city);
        _cityService.UpdateCity(cityId, city);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{cityId}")]
    public async Task<IActionResult> DeleteCityById(long cityId)
    {
      try
      {
        var city = await _cityService.GetCityById(cityId);
        if (city == null) return NotFound();
        // not an actual delete
        city.Status = Status.Deleted;
        _cityService.UpdateCity(cityId, city);
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