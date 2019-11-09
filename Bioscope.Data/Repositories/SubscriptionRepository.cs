using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
  public interface ISubscriptionRepository : IRepository<Subscription>
  {

  }
  public class SubscriptionRepository : RepositoryBase<DataContext, Subscription>, ISubscriptionRepository
  {
    public SubscriptionRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory)
    {
    }
  }
}