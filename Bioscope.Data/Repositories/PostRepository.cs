using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
  public interface IPostRepository : IRepository<Post>
  {

  }
  public class PostRepository : RepositoryBase<DataContext, Post>, IPostRepository
  {
    public PostRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory) { }
  }
}