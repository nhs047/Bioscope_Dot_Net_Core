using System;
using System.Threading.Tasks;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;
using Bioscope.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Bioscope.App.API
{
  [Route("api/[controller]")]
  [ApiController]
  public class DropdownController : ControllerBase
  {
    private readonly IDropdownService _dropdownService;

    public DropdownController(IDropdownService dropdownService)
    {
      _dropdownService = dropdownService;
    }

    [HttpGet("features")]
    public async Task<IActionResult> GetFeatures()
    {
      try
      {
        var items = await _dropdownService.GetItems<Feature>(x => x.Name, y => y.Id.ToString(), c => c.Status != Status.Deleted);
        return Ok(items);
      }
      catch (Exception)
      {
        return Ok(new string[0]);
      }
    }
  }
}