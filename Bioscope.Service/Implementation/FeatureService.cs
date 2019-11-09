using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class FeatureService : IFeatureService
  {
    private readonly IFeatureRepository _featureRepository;

    public FeatureService(IFeatureRepository featureRepository) => _featureRepository = featureRepository;

    public void AddFeature(Feature feature) => _featureRepository.Add(feature);

    public async Task<IEnumerable<Feature>> GetAllFeatures() => await _featureRepository.GetAll(x => x.Status != Status.Deleted);

    public async Task<Feature> GetFeatureById(long id) => await _featureRepository.GetById(id);

    public void RemoveFeature(Feature feature) => _featureRepository.Delete(feature);

    public void UpdateFeature(long id, Feature feature) => _featureRepository.Update(feature);
  }
}