using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
  public interface IStateRepository : IRepository<State>
  {

  }
  public class StateRepository : RepositoryBase<DataContext, State>, IStateRepository
  {
    public StateRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory) { }
  }
}