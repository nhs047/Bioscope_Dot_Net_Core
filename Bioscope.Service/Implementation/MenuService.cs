using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class MenuService : IMenuService
  {
    private readonly IMenuRepository _menuRepository;
    public MenuService(IMenuRepository menuRepository) => _menuRepository = menuRepository;

    public void AddMenu(Menu menu) => _menuRepository.Add(menu);

    public async Task<IEnumerable<Menu>> GetAllMenus() => await _menuRepository.GetAll(x=> x.Status != Status.Deleted);

    public async Task<Menu> GetMenuById(long id) => await _menuRepository.GetById(id);

    public void RemoveMenu(Menu menu) => _menuRepository.Delete(menu);

    public void UpdateMenu(long id, Menu menu) => _menuRepository.Update(menu);
    }
}