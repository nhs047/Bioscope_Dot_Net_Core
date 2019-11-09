using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bioscope.App.Dtos;
using Bioscope.App.Helpers;
using Bioscope.Data.Entities;
using Bioscope.Infrastructure;
using Bioscope.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Bioscope.App.API
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthenticationController : ControllerBase
  {
    private readonly IAuthenticationService _authenticationService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOptions<Middleware> _config;
    private readonly IMapper _mapper;

    public AuthenticationController(IAuthenticationService authenticationService, IOptions<Middleware> config, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _authenticationService = authenticationService;
      _config = config;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup(SignupDto data)
    {
      try
      {
        var signupData = _mapper.Map<User>(data);
        _authenticationService.Register(signupData, data.Password);
        await _unitOfWork.Save();
        var authData = _mapper.Map<AuthDto>(signupData);
        return Ok(authData);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("signin")]
    public async Task<IActionResult> Signin(SigninDto data)
    {
      try
      {
        var loginData = await _authenticationService.Login(data.UserName.ToLower(), data.Password);
        if (loginData == null) return Unauthorized();

        var claims = new []
        {
          new Claim(ClaimTypes.NameIdentifier, loginData.Id.ToString()),
          new Claim(ClaimTypes.Name, loginData.UserName)
        };

        var privateKey = _config.Value.Token;
        var key = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(privateKey)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
          Subject = new ClaimsIdentity(claims),
          Expires = DateTime.Now.AddDays(7),
          SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        var user = _mapper.Map<AuthDto>(loginData);

        return Ok(new AuthReturnDto
        {
          User = user,
          Token = tokenHandler.WriteToken(token)
        });
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}