using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class PostCategoryService : IPostCategoryService
  {
    private readonly IPostCategoryRepository _postCategoryRepository;
    public PostCategoryService(IPostCategoryRepository postCategoryRepository) => _postCategoryRepository = postCategoryRepository;

    public void AddPostCategory(PostCategory postCategory) => _postCategoryRepository.Add(postCategory);

    public async Task<IEnumerable<PostCategory>> GetAllPostCategories() => await _postCategoryRepository.GetAll(x => x.Status != Status.Deleted);

    public async Task<PostCategory> GetPostCategoryById(long id) => await _postCategoryRepository.GetById(id);

    public void RemovePostCategory(PostCategory postCategory) => _postCategoryRepository.Delete(postCategory);

    public void UpdatePostCategory(long id, PostCategory postCategory) => _postCategoryRepository.Update(postCategory);
  }
}