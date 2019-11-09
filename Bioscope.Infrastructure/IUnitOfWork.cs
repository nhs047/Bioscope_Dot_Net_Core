using System.Threading.Tasks;

namespace Bioscope.Infrastructure
{
  public interface IUnitOfWork
  {
    IEntityTransaction BeginTransaction();
    Task<int> Save();
  }
}