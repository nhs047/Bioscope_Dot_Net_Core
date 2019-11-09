using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
  public interface ICategoryRepository : IRepository<Category>
  {

  }
  
  public class CategoryRepository : RepositoryBase<DataContext, Category>, ICategoryRepository
  {
    public CategoryRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory) { }
  }
}