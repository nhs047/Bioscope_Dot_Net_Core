using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class UploadService : IUploadService
  {
    private readonly IUploadRepository _uploadRepository;

    public UploadService(IUploadRepository uploadRepository)
    {
      _uploadRepository = uploadRepository;
    }

    public void AddUpload(Upload upload)
    {
      _uploadRepository.Add(upload);
    }

    public void AddUploads(IEnumerable<Upload> uploads)
    {
      _uploadRepository.AddRange(uploads);
    }

    public async Task<IEnumerable<Upload>> GetAllUploads()
    {
      return await _uploadRepository.GetAll();
    }

    public async Task<Upload> GetUploadById(long id)
    {
      return await _uploadRepository.GetById(id);
    }

    public void RemoveUpload(Upload upload)
    {
      _uploadRepository.Delete(upload);
    }

    public void UpdateUpload(long id, Upload upload)
    {
      _uploadRepository.Update(upload);
    }
  }
}