using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface IMenuService
  {
    Task<IEnumerable<Menu>> GetAllMenus();
    Task<Menu> GetMenuById(long id);
    void AddMenu(Menu menu);
    void UpdateMenu(long id, Menu menu);
    void RemoveMenu(Menu menu);
  }
}