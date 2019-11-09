using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Repositories;
using Bioscope.Service.Abstraction;

namespace Bioscope.Service.Implementation
{
  public class AuthenticationService : IAuthenticationService
  {
    private readonly IAuthenticationRepository _authenticationRepository;
    public AuthenticationService(IAuthenticationRepository authenticationRepository) => _authenticationRepository = authenticationRepository;

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using(var hmac = new HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
      }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
      using(var hmac = new HMACSHA512(passwordSalt))
      {
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
          if (computedHash[i] != passwordHash[i]) return false;
        }
        return true;
      }
    }

    public async Task<User> Login(string userName, string password)
    {
      var user = await _authenticationRepository.Get(x => x.UserName == userName || x.Email == userName);
      if (user == null) return null;
      if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;
      return user;
    }

    public void Register(User user, string password)
    {
      byte[] passwordHash, passwordSalt;
      CreatePasswordHash(password, out passwordHash, out passwordSalt);

      user.PasswordHash = passwordHash;
      user.PasswordSalt = passwordSalt;
      _authenticationRepository.Add(user);
    }

    public async Task<bool> UserExists()
    {
      var isExist = await _authenticationRepository.GetAny();
      return isExist;
    }
    public async Task<bool> UserExists(string param)
    {
      var isUserExist = await _authenticationRepository.GetAny(x => x.UserName == param || x.Email == param);
      return isUserExist;
    }

  }
}