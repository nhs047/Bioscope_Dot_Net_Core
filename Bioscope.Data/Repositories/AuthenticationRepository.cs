using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
    public interface IAuthenticationRepository : IRepository<User>
    {
        
    }
    public class AuthenticationRepository : RepositoryBase<DataContext, User>, IAuthenticationRepository
    {
        public AuthenticationRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory)
        {
        }
    }
}