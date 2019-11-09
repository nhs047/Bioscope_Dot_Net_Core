using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface IPostCategoryService
  {
    Task<IEnumerable<PostCategory>> GetAllPostCategories();
    Task<PostCategory> GetPostCategoryById(long id);
    void AddPostCategory(PostCategory postCategory);
    void UpdatePostCategory(long id, PostCategory postCategory);
    void RemovePostCategory(PostCategory postCategory);
  }
}