using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface ISubscriptionService
  {
    Task<IEnumerable<Subscription>> GetAllSubscriptions();
    Task<Subscription> GetSubscriptionById(long id);
    void AddSubscription(Subscription subscription);
    void UpdateSubscription(long id, Subscription subscription);
    void RemoveSubscription(Subscription subscription);
  }
}