using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class PostService : IPostService
  {
    private readonly IPostRepository _postRepository;
    public PostService(IPostRepository postRepository) => _postRepository = postRepository;

    public void AddPost(Post post) => _postRepository.Add(post);

    public async Task<IEnumerable<Post>> GetAllPosts() => await _postRepository.GetAll(x => x.Status != Status.Deleted);

    public async Task<Post> GetPostById(long id) => await _postRepository.GetById(id);

    public void RemovePost(Post post) => _postRepository.Delete(post);

    public void UpdatePost(long id, Post post) => _postRepository.Update(post);
  }
}