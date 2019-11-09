using System.Threading.Tasks;
using Bioscope.Data.Entities;

namespace Bioscope.Service.Abstraction
{
  public interface IAuthenticationService
  {
    void Register(User user, string password);
    Task<User> Login(string userName, string password);

    // @param can be username or email
    Task<bool> UserExists(string param);
    Task<bool> UserExists();
  }
}