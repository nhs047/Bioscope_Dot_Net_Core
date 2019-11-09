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
  public class RolesController : ControllerBase
  {
    private readonly IRoleService _roleService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RolesController(IRoleService roleService, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _roleService = roleService;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        var roles = await _roleService.GetAllRoles();
        var mappedRoles = _mapper.Map<IEnumerable<RoleDto>>(roles);
        return Ok(mappedRoles);
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpGet("{roleId}")]
    public async Task<IActionResult> GetRoleById(long? roleId)
    {
      try
      {
        if (roleId == null) return BadRequest();
        var role = await _roleService.GetRoleById((long) roleId);
        var mappedRole = _mapper.Map<RoleDto>(role);
        return Ok(mappedRole);
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(RoleDto roleDto)
    {
      try
      {
        var role = _mapper.Map<Role>(roleDto);
        _roleService.AddRole(role);
        await _unitOfWork.Save();
        return Ok(role);
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpPut("{roleId}")]
    public async Task<IActionResult> UpdateRoleById(long roleId, RoleDto roleDto)
    {
      try
      {
        if (roleId != roleDto.Id) return BadRequest();
        var role = await _roleService.GetRoleById(roleId);
        if (role == null) return NotFound();
        _mapper.Map(roleDto, role);
        _roleService.UpdateRole(roleId, role);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpDelete("{roleId}")]
    public async Task<IActionResult> DeleteRoleById(long roleId)
    {
      try
      {
        var role = await _roleService.GetRoleById(roleId);
        if (role == null) return NotFound();
        if (role.Name.ToLower() == "superadmin" || role.Name.ToLower() == "super admin")
        {
          return BadRequest("Super Admin Role cannnot be deleted");
        }
        // not an actual delete
        role.Status = Status.Deleted;
        _roleService.UpdateRole(roleId, role);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }
  }
}