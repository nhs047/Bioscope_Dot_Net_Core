using System;
using System.Threading.Tasks;
using Bioscope.App.Areas.Admin.ViewModels;
using Bioscope.App.Dtos;
using Bioscope.App.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bioscope.App.Areas.Admin.Controllers
{
  [Area("Admin")]
  [Route("[area]/auth")]
  public class AuthenticationController : Controller
  {
    private readonly HttpService _httpService;
    public AuthenticationController(HttpService httpService)
    {
      _httpService = httpService;
    }

    [Route("")]
    [HttpGet("signin")]
    public IActionResult SignIn()
    {
      try
      {
        return View();
      }
      catch (Exception)
      {
        return RedirectToAction("Index", "Home");
      }
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {
      try
      {
        var response = await _httpService.Api.PostAsJsonAsync("/api/authentication/signin", viewModel);
        if (!response.IsSuccessStatusCode) return View().NotifyError("Invalid credential, try again!");
        var authData = await response.Content.ReadAsJsonAsync<AuthReturnDto>();
        var options = new CookieOptions
        {
          Expires = DateTime.Now.AddDays(10),
          //HttpOnly = true
        };
        Response.Cookies.Append(Constant.AuthData, JsonConvert.SerializeObject(authData), options);
        return RedirectToAction("Index", "Home");
      }
      catch (Exception)
      {
        return View();
      }
    }

  }
}