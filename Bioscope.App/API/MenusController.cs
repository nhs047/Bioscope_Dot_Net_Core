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
  public class MenusController : ControllerBase
  {
    private readonly IMenuService _menuService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public MenusController(IMenuService menuService, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _menuService = menuService;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        var menus = await _menuService.GetAllMenus();
        var mappedMenus = _mapper.Map<IEnumerable<MenuDto>>(menus);
        return Ok(mappedMenus);
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpGet("{menuId}")]
    public async Task<IActionResult> GetMenuById(long? menuId)
    {
      try
      {
        if (menuId == null) return BadRequest();
        var menu = await _menuService.GetMenuById((long) menuId);
        var mappedMenu = _mapper.Map<MenuDto>(menu);
        return Ok(mappedMenu);
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpPost]
    public async Task<IActionResult> AddMenu(MenuDto menuDto)
    {
      try
      {
        var menu = _mapper.Map<Menu>(menuDto);
        _menuService.AddMenu(menu);
        await _unitOfWork.Save();
        return Ok(menu);
      }
      catch (Exception ex)
      {
        return BadRequest();
      }
    }

    [HttpPut("{menuId}")]
    public async Task<IActionResult> UpdateMenuById(long menuId, MenuDto menuDto)
    {
      try
      {
        if (menuId != menuDto.Id) return BadRequest();
        var menu = await _menuService.GetMenuById(menuId);
        if (menu == null) return NotFound();
        _mapper.Map(menuDto, menu);
        _menuService.UpdateMenu(menuId, menu);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpDelete("{menuId}")]
    public async Task<IActionResult> DeleteMenuById(long menuId)
    {
      try
      {
        var menu = await _menuService.GetMenuById(menuId);
        if (menu == null) return NotFound();
        menu.Status = Status.Deleted;
        _menuService.UpdateMenu(menuId, menu);
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