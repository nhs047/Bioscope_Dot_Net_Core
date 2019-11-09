using System.Threading.Tasks;
using Bioscope.App.Dtos;
using Bioscope.App.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Bioscope.App.Controllers
{
  public class AuthenticationController : Controller
  {
    private readonly HttpService _httpService;

    public AuthenticationController(HttpService httpService) => _httpService = httpService;

    // Get Authentication/signup
    public ActionResult Signup()
    {
      return View(new SignupDto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Signup(SignupDto data)
    {
      try
      {
        var response = await _httpService.Api.PostAsJsonAsync("/api/authentication/", data);
        if (response.IsSuccessStatusCode)
        {
          return RedirectToRoute("Home");
        }
        return View(data);
      }
      catch (System.Exception)
      {
        throw;
      }
    }

  }
}