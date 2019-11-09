using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class RoleService : IRoleService
  {
    private readonly IRoleRepository _roleRepository;
    public RoleService(IRoleRepository roleRepository) => _roleRepository = roleRepository;

    public void AddRole(Role role) => _roleRepository.Add(role);

    public void AddRoles(IEnumerable<Role> roles) => _roleRepository.AddRange(roles);

    public async Task<IEnumerable<Role>> GetAllRoles() => await _roleRepository.GetAll(x => x.Status != Status.Deleted);

    public async Task<Role> GetRoleById(long id) => await _roleRepository.GetById(id);

    public void RemoveRole(Role role) => _roleRepository.Delete(role);

    public async Task<bool> RoleExists() => await _roleRepository.GetAny();

    public void UpdateRole(long id, Role role) => _roleRepository.Update(role);
  }
}