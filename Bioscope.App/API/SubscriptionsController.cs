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
  public class SubscriptionsController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionsController(ISubscriptionService subscriptionService, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _subscriptionService = subscriptionService;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSubscriptions()
    {
      try
      {
        var subscriptions = await _subscriptionService.GetAllSubscriptions();
        var mappedSubscriptions = _mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);
        return Ok(mappedSubscriptions);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    public async Task<IActionResult> GetSubscriptionById(long? id)
    {
      try
      {
        if (id == null) return BadRequest();
        var subscription = await _subscriptionService.GetSubscriptionById((long) id);
        var mappedSubscription = _mapper.Map<SubscriptionDto>(subscription);
        return Ok(mappedSubscription);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> AddSubscription(SubscriptionDto subscriptionDto)
    {
      try
      {
        var subscription = _mapper.Map<Subscription>(subscriptionDto);
        _subscriptionService.AddSubscription(subscription);
        await _unitOfWork.Save();
        return Ok(subscription);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{subscriptionId}")]
    public async Task<IActionResult> UpdateSubscriptionById(long subscriptionId, SubscriptionDto subscriptionDto)
    {
      try
      {
        if (subscriptionId != subscriptionDto.Id) return BadRequest();
        var subscription = await _subscriptionService.GetSubscriptionById(subscriptionId);
        if (subscription == null) return NotFound();
        _mapper.Map(subscriptionDto, subscription);
        _subscriptionService.UpdateSubscription(subscriptionId, subscription);
        await _unitOfWork.Save();
        return NoContent();
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }

    [HttpDelete("{subscriptionId}")]
    public async Task<IActionResult> DeleteSubscriptionById(long subscriptionId)
    {
      try
      {
        var subscription = await _subscriptionService.GetSubscriptionById(subscriptionId);
        if (subscription == null) return NotFound();
        // not an actual delete
        subscription.Status = Status.Deleted;
        _subscriptionService.UpdateSubscription(subscriptionId, subscription);
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