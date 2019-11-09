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
  public class RoleFeaturesController : ControllerBase
  {
    private readonly IRoleFeatureService _roleFeatureService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RoleFeaturesController(IRoleFeatureService roleFeatureService, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _roleFeatureService = roleFeatureService;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        var roles = await _roleFeatureService.GetAllRoleFeatures();
        var mappedRoleFeatures = _mapper.Map<IEnumerable<RoleFeatureDto>>(roles);
        return Ok(mappedRoleFeatures);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{roleFeatureId}")]
    public async Task<IActionResult> GetRoleFeatureById(long? roleFeatureId)
    {
      try
      {
        if (roleFeatureId == null) return BadRequest();
        var roleFeature = await _roleFeatureService.GetRoleFeatureById((long) roleFeatureId);
        var mappedRoleFeature = _mapper.Map<RoleFeatureDto>(roleFeature);
        return Ok(mappedRoleFeature);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> AddRoleFeature(RoleFeatureDto roleFeatureDto)
    {
      try
      {
        var roleFeature = _mapper.Map<RoleFeature>(roleFeatureDto);
        _roleFeatureService.AddRoleFeature(roleFeature);
        await _unitOfWork.Save();
        return Ok(roleFeature);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{roleFeatureId}")]
    public async Task<IActionResult> UpdateRoleFeatureById(long roleFeatureId, RoleFeatureDto roleFeatureDto)
    {
      try
      {
        if (roleFeatureId != roleFeatureDto.Id) return BadRequest();
        var roleFeature = await _roleFeatureService.GetRoleFeatureById(roleFeatureId);
        if (roleFeature == null) return NotFound();
        _mapper.Map(roleFeatureDto, roleFeature);
        _roleFeatureService.UpdateRoleFeature(roleFeatureId, roleFeature);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{roleFeatureId}")]
    public async Task<IActionResult> DeleteRoleFeatureById(long roleFeatureId)
    {
      try
      {
        var roleFeature = await _roleFeatureService.GetRoleFeatureById(roleFeatureId);
        if (roleFeature == null) return NotFound();
        // not an actual delete
        roleFeature.Status = Status.Deleted;
        _roleFeatureService.UpdateRoleFeature(roleFeatureId, roleFeature);
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