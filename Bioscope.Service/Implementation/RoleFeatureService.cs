using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class RoleFeatureService : IRoleFeatureService
  {
    private readonly IRoleFeatureRepository _roleFeatureRepository;
    public RoleFeatureService(IRoleFeatureRepository roleFeatureRepository) => _roleFeatureRepository = roleFeatureRepository;

    public void AddRoleFeature(RoleFeature roleFeature) => _roleFeatureRepository.Add(roleFeature);

    public async Task<IEnumerable<RoleFeature>> GetAllRoleFeatures() => await _roleFeatureRepository.GetAll(x => x.Status != Status.Deleted);

    public async Task<RoleFeature> GetRoleFeatureById(long id) => await _roleFeatureRepository.GetById(id);

    public void RemoveRoleFeature(RoleFeature roleFeature) => _roleFeatureRepository.Delete(roleFeature);

    public void UpdateRoleFeature(long id, RoleFeature roleFeature) => _roleFeatureRepository.Update(roleFeature);
  }
}