using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface IFeatureService
  {
    Task<IEnumerable<Feature>> GetAllFeatures();
    Task<Feature> GetFeatureById(long id);
    void AddFeature(Feature feature);
    void UpdateFeature(long id, Feature feature);
    void RemoveFeature(Feature feature);
  }
}