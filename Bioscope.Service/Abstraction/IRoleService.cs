using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface IRoleService
  {
    Task<IEnumerable<Role>> GetAllRoles();
    Task<Role> GetRoleById(long id);
    void AddRole(Role role);
    void AddRoles(IEnumerable<Role> roles);
    void UpdateRole(long id, Role role);
    void RemoveRole(Role role);

    Task<bool> RoleExists();
  }
}