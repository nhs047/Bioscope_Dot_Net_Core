using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface ICategoryService
  {
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryById(long id);
    void AddCategory(Category category);
    void UpdateCategory(long id, Category category);
    void RemoveCategory(Category category);
  }
}