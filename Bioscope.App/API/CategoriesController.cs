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
  public class CategoriesController : ControllerBase
  {
    private readonly ICategoryService _categoryService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CategoriesController(ICategoryService categoryService, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _categoryService = categoryService;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        var categories = await _categoryService.GetAllCategories();
        var mappedCategories = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        return Ok(mappedCategories);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetCategoryById(long? categoryId)
    {
      try
      {
        if (categoryId == null) return BadRequest();
        var category = await _categoryService.GetCategoryById((long) categoryId);
        var mappedCategory = _mapper.Map<CategoryDto>(category);
        return Ok(mappedCategory);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
    {
      try
      {
        var category = _mapper.Map<Category>(categoryDto);
        _categoryService.AddCategory(category);
        await _unitOfWork.Save();
        return Ok(category);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{categoryId}")]
    public async Task<IActionResult> UpdateCategoryById(long categoryId, CategoryDto categoryDto)
    {
      try
      {
        if (categoryId != categoryDto.Id) return BadRequest();
        var category = await _categoryService.GetCategoryById(categoryId);
        if (category == null) return NotFound();
        _mapper.Map(categoryDto, category);
        _categoryService.UpdateCategory(categoryId, category);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteCategoryById(long categoryId)
    {
      try
      {
        var category = await _categoryService.GetCategoryById(categoryId);
        if (category == null) return NotFound();
        // not an actual delete
        category.Status = Status.Deleted;
        _categoryService.UpdateCategory(categoryId, category);
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