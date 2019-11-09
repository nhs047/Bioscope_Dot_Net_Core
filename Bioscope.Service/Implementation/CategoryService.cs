using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class CategoryService : ICategoryService
  {
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public void AddCategory(Category category) => _categoryRepository.Add(category);

    public async Task<IEnumerable<Category>> GetAllCategories() => await _categoryRepository.GetAll(x => x.Status != Status.Deleted);

    public async Task<Category> GetCategoryById(long id) => await _categoryRepository.GetById(id);

    public void RemoveCategory(Category category) => _categoryRepository.Delete(category);

    public void UpdateCategory(long id, Category category) => _categoryRepository.Update(category);
  }
}