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
  public class FeaturesController : ControllerBase
  {
    private readonly IFeatureService _featureService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FeaturesController(IFeatureService featureService, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
      _featureService = featureService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        var features = await _featureService.GetAllFeatures();
        var mappedFeatures = _mapper.Map<IEnumerable<FeatureDto>>(features);
        return Ok(mappedFeatures);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{featureId}")]
    public async Task<IActionResult> GetFeatureById(long? featureId)
    {
      try
      {
        if (featureId == null) return BadRequest();
        var feature = await _featureService.GetFeatureById((long) featureId);
        var mappedFeature = _mapper.Map<FeatureDto>(feature);
        return Ok(mappedFeature);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> AddFeature(FeatureDto featureDto)
    {
      try
      {
        var feature = _mapper.Map<Feature>(featureDto);
        feature.Status = Status.Authorized;
        _featureService.AddFeature(feature);
        await _unitOfWork.Save();
        return Ok(feature);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{featureId}")]
    public async Task<IActionResult> UpdateFeatureById(long featureId, FeatureDto featureDto)
    {
      try
      {
        if (featureId != featureDto.Id) return BadRequest();
        var feature = await _featureService.GetFeatureById(featureId);
        if (feature == null) return NotFound();
        var status = feature.Status;
        _mapper.Map(featureDto, feature);
        feature.Status = status;
        _featureService.UpdateFeature(featureId, feature);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpDelete("{featureId}")]
    public async Task<IActionResult> DeleteFeatureById(long featureId)
    {
      try
      {
        var feature = await _featureService.GetFeatureById(featureId);
        if (feature == null) return NotFound();
        // not an actual delete
        feature.Status = Status.Deleted;
        _featureService.UpdateFeature(featureId, feature);
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