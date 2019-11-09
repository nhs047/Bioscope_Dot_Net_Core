using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface IRoleFeatureService
  {
    Task<IEnumerable<RoleFeature>> GetAllRoleFeatures();
    Task<RoleFeature> GetRoleFeatureById(long id);
    void AddRoleFeature(RoleFeature roleFeature);
    void UpdateRoleFeature(long id, RoleFeature roleFeature);
    void RemoveRoleFeature(RoleFeature roleFeature);
  }
}