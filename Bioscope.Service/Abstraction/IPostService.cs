using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface IPostService
  {
    Task<IEnumerable<Post>> GetAllPosts();
    Task<Post> GetPostById(long id);
    void AddPost(Post post);
    void UpdatePost(long id, Post post);
    void RemovePost(Post post);
  }
}