using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Bioscope.App.Dtos;
using Bioscope.Data.Entities;
using Bioscope.Infrastructure;
using Bioscope.Service.Abstraction;
using Newtonsoft.Json;

namespace Bioscope.App.Seeds
{
  public class Seed
  {
    private readonly IAuthenticationService _authenticationService;
    private readonly IRoleService _roleService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public Seed(IAuthenticationService authenticationService, IRoleService roleService, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _authenticationService = authenticationService;
      _roleService = roleService;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    private async Task<bool> ShouldRunSeeds()
    {
      try
      {
        var isAnyUserExists = await _authenticationService.UserExists();
        var isRolesExists = await _roleService.RoleExists();
        if (isAnyUserExists || isRolesExists) return false;
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
    private async Task<bool> SeedRoles()
    {
      using(var transation = _unitOfWork.BeginTransaction())
      {
        try
        {
          var rolesData = File.ReadAllText("Seeds/RoleSeedData.json");
          var roles = JsonConvert.DeserializeObject<List<Role>>(rolesData);
          _roleService.AddRoles(roles);
          await _unitOfWork.Save();
          transation.Commit();
          return true;
        }
        catch (Exception)
        {
          transation.Rollback();
          return false;
        }
      }
    }

    private async Task<bool> SeedUsers()
    {
      using(var transation = _unitOfWork.BeginTransaction())
      {
        try
        {
          var usersData = File.ReadAllText("Seeds/UserSeedData.json");
          var users = JsonConvert.DeserializeObject<List<SignupDto>>(usersData);
          foreach (var user in users)
          {
            var authData = _mapper.Map<User>(user);
            _authenticationService.Register(authData, user.Password);
            await _unitOfWork.Save();
          }
          transation.Commit();
          return true;
        }
        catch (Exception)
        {
          transation.Rollback();
          return false;
        }
      }
    }
    public void Run()
    {
      Task<bool> shouldRun = ShouldRunSeeds();
      if (!shouldRun.Result) return;
      Task<bool> isSeeded = SeedRoles();
      if (isSeeded.Result) isSeeded = SeedUsers();
    }
  }
}