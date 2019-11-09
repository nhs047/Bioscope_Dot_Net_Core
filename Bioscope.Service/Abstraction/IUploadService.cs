using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface IUploadService
  {
    Task<IEnumerable<Upload>> GetAllUploads();
    Task<Upload> GetUploadById(long id);
    void AddUpload(Upload upload);
    void AddUploads(IEnumerable<Upload> uploads);
    void UpdateUpload(long id, Upload upload);
    void RemoveUpload(Upload upload);
  }
}