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
  public class PostCategoriesController : ControllerBase
  {
    private readonly IPostCategoryService _postCategoryService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PostCategoriesController(IPostCategoryService postCategoryService, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _postCategoryService = postCategoryService;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        var categories = await _postCategoryService.GetAllPostCategories();
        var mappedPostCategories = _mapper.Map<IEnumerable<PostCategoryDto>>(categories);
        return Ok(mappedPostCategories);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{postCategoryId}")]
    public async Task<IActionResult> GetPostCategoryById(long? postCategoryId)
    {
      try
      {
        if (postCategoryId == null) return BadRequest();
        var postCategory = await _postCategoryService.GetPostCategoryById((long) postCategoryId);
        var mappedPostCategory = _mapper.Map<PostCategoryDto>(postCategory);
        return Ok(mappedPostCategory);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> AddPostCategory(PostCategoryDto postCategoryDto)
    {
      try
      {
        var postCategory = _mapper.Map<PostCategory>(postCategoryDto);
        _postCategoryService.AddPostCategory(postCategory);
        await _unitOfWork.Save();
        return Ok(postCategory);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{postCategoryId}")]
    public async Task<IActionResult> UpdatePostCategoryById(long postCategoryId, PostCategoryDto postCategoryDto)
    {
      try
      {
        if (postCategoryId != postCategoryDto.Id) return BadRequest();
        var postCategory = await _postCategoryService.GetPostCategoryById(postCategoryId);
        if (postCategory == null) return NotFound();
        _mapper.Map(postCategoryDto, postCategory);
        _postCategoryService.UpdatePostCategory(postCategoryId, postCategory);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{postCategoryId}")]
    public async Task<IActionResult> DeletePostCategoryById(long postCategoryId)
    {
      try
      {
        var postCategory = await _postCategoryService.GetPostCategoryById(postCategoryId);
        if (postCategory == null) return NotFound();
        // not an actual delete
        postCategory.Status = Status.Deleted;
        _postCategoryService.UpdatePostCategory(postCategoryId, postCategory);
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