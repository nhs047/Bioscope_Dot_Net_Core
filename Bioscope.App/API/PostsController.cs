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
  // todo need to reactor
  [Route("api/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    private readonly IPostService _postService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PostsController(IPostService postService, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _postService = postService;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        var posts = await _postService.GetAllPosts();
        var mappedPosts = _mapper.Map<IEnumerable<PostDto>>(posts);
        return Ok(mappedPosts);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetPostById(long? postId)
    {
      try
      {
        if (postId == null) return BadRequest();
        var post = await _postService.GetPostById((long) postId);
        var mappedPost = _mapper.Map<PostDto>(post);
        return Ok(mappedPost);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> AddPost(PostDto postDto)
    {
      try
      {
        var post = _mapper.Map<Post>(postDto);
        _postService.AddPost(post);
        await _unitOfWork.Save();
        return Ok(post);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{postId}")]
    public async Task<IActionResult> UpdatePostById(long postId, PostDto postDto)
    {
      try
      {
        if (postId != postDto.Id) return BadRequest();
        var post = await _postService.GetPostById(postId);
        if (post == null) return NotFound();
        _mapper.Map(postDto, post);
        _postService.UpdatePost(postId, post);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{postId}")]
    public async Task<IActionResult> DeletePostById(long postId)
    {
      try
      {
        var post = await _postService.GetPostById(postId);
        if (post == null) return NotFound();
        // not an actual delete
        post.Status = Status.Deleted;
        _postService.UpdatePost(postId, post);
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