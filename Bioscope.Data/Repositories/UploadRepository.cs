using Bioscope.Data.Entities;
using Bioscope.Infrastructure;

namespace Bioscope.Data.Repositories
{
  public interface IUploadRepository : IRepository<Upload>
  {

  }
  public class UploadRepository : RepositoryBase<DataContext, Upload>, IUploadRepository
  {
    public UploadRepository(IDbFactory<DataContext> dbFactory) : base(dbFactory) { }
  }
}