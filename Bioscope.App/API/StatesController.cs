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
  public class StatesController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStateService _stateService;

    public StatesController(IStateService stateService, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _stateService = stateService;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStates()
    {
      try
      {
        var states = await _stateService.GetAllStates();
        var mappedStates = _mapper.Map<IEnumerable<StateDto>>(states);
        return Ok(mappedStates);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    public async Task<IActionResult> GetStateById(long? id)
    {
      try
      {
        if (id == null) return BadRequest();
        var state = await _stateService.GetStateById((long) id);
        var mappedState = _mapper.Map<SubscriptionDto>(state);
        return Ok(mappedState);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> AddSubscription(StateDto stateDto)
    {
      try
      {
        var state = _mapper.Map<State>(stateDto);
        _stateService.AddState(state);
        await _unitOfWork.Save();
        return Ok(state);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{stateId}")]
    public async Task<IActionResult> UpdateStateById(long stateId, StateDto stateDto)
    {
      try
      {
        if (stateId != stateDto.Id) return BadRequest();
        var state = await _stateService.GetStateById(stateId);
        if (state == null) return NotFound();
        _mapper.Map(stateDto, state);
        _stateService.UpdateState(stateId, state);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{stateId}")]
    public async Task<IActionResult> DeleteStateById(long stateId)
    {
      try
      {
        var state = await _stateService.GetStateById(stateId);
        if (state == null) return NotFound();
        // not an actual delete
        state.Status = Status.Deleted;
        _stateService.UpdateState(stateId, state);
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