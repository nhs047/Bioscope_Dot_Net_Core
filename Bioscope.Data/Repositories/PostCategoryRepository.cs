using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
  public interface IPostCategoryRepository : IRepository<PostCategory>
  {

  }
  public class PostCategoryRepository : RepositoryBase<DataContext, PostCategory>, IPostCategoryRepository
  {
    public PostCategoryRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory) { }
  }
}