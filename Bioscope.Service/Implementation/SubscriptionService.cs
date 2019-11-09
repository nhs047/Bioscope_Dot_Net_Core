using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class SubscriptionService : ISubscriptionService
  {
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(ISubscriptionRepository subscriptionRepository)
    {
      _subscriptionRepository = subscriptionRepository;
    }
    public void AddSubscription(Subscription subscription)
    {
      _subscriptionRepository.Add(subscription);
    }

    public async Task<IEnumerable<Subscription>> GetAllSubscriptions()
    {
      return await _subscriptionRepository.GetAll();
    }

    public async Task<Subscription> GetSubscriptionById(long id)
    {
      return await _subscriptionRepository.GetById(id);
    }

    public void RemoveSubscription(Subscription subscription)
    {
      _subscriptionRepository.Delete(subscription);
    }

    public void UpdateSubscription(long id, Subscription subscription)
    {
      _subscriptionRepository.Update(subscription);
    }
  }
}