using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bioscope.App.Helpers;
using Bioscope.App.Models;
using Bioscope.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bioscope.App.Controllers
{
  public class HomeController : Controller
  {
    private readonly HttpService _http;
    public HomeController(HttpService http)
    {
      _http = http;
    }

    public async Task<IActionResult> Index()
    {
      var response = await _http.Api.GetAsync("/api/menu/all");
      var result = await response.Content.ReadAsJsonAsync<List<Menu>>();      
      return View();
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Your application description page.";

      return View();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}