using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.App.Areas.Admin.ViewModels;
using Bioscope.App.Dtos;
using Bioscope.App.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bioscope.App.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class FeaturesController : Controller
  {
    private readonly HttpService _httpService;
    public FeaturesController(HttpService httpService)
    {
      _httpService = httpService;
    }

    // GET: Features
    public async Task<IActionResult> Index(FeatureViewModel viewModel)
    {
      try
      {
        viewModel.PageHeader = new PageHeaderViewModel
        {
          Title = "Features",
          PageLink = "/admin/features/",
          CreatePage = "/admin/features/create"
        };
        var response = await _httpService.Api.GetAsync("/api/features");
        if (!response.IsSuccessStatusCode) return RedirectToAction("Index", "Home").NotifyBadRequest();
        viewModel.Features = await response.Content.ReadAsJsonAsync<List<FeatureDto>>();

        // Reading coockies demo
        // todo remove
        var json = Request.Cookies[Constant.AuthData];
        var authdata = JsonConvert.DeserializeObject<AuthReturnDto>(json);

        return View(viewModel);
      }
      catch (Exception ex)
      {
        return RedirectToAction("Index", "Home").NotifyError(ex.Message);
      }
    }

    // GET: Features/Details/5
    public async Task<ActionResult> Details(long? id)
    {
      try
      {
        if (id == null) return RedirectToAction(nameof(Index));
        var viewModel = new FeatureViewModel
        {
          PageHeader = new PageHeaderViewModel
          {
          Title = "Feature Details",
          PageLink = $"/admin/features/details/{id}",
          Target = "/admin/features/",
          CreatePage = "/admin/features/create"
          }
        };

        var response = await _httpService.Api.GetAsync($"/api/features/{id}");
        if (!response.IsSuccessStatusCode) return RedirectToAction(nameof(Index)).NotifyBadRequest();
        viewModel.Feature = await response.Content.ReadAsJsonAsync<FeatureDto>();
        return View(viewModel);
      }
      catch (Exception ex)
      {
        return RedirectToAction(nameof(Index)).NotifyError(ex.Message);
      }
    }

    // GET: Features/Create
    public ActionResult Create()
    {
      var vm = new FeatureViewModel
      {
        PageHeader = new PageHeaderViewModel
        {
        Title = "Add New Feature",
        FormName = "addFeatureForm",
        Target = "/admin/features/"
        }
      };
      return View(vm);
    }

    // POST: Features/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(FeatureViewModel viewModel)
    {
      try
      {
        viewModel.PageHeader = new PageHeaderViewModel
        {
          Title = "Features",
          FormName = "addFeatureForm",
          Target = "/admin/features/"
        };
        if (!TryValidateModel(viewModel.Feature)) return View(viewModel).NotifyValidationError();
        var response = await _httpService.Api.PostAsJsonAsync("/api/features", viewModel.Feature);
        if (!response.IsSuccessStatusCode) return View(viewModel).NotifyBadRequest();
        return RedirectToAction(nameof(Index)).NotifySaved();
      }
      catch (Exception ex)
      {
        return View(viewModel).NotifyError(ex.Message);
      }
    }

    // GET: Features/Edit/5
    public async Task<ActionResult> Edit(long? id)
    {
      try
      {
        if (id == null) return RedirectToAction(nameof(Index)).NotifyBadRequest();
        var viewModel = new FeatureViewModel
        {
          PageHeader = new PageHeaderViewModel
          {
          Title = "Edit Feature",
          FormName = "editFeatureForm",
          Target = "/admin/features/"
          }
        };
        var response = await _httpService.Api.GetAsync($"/api/features/{id}");
        if (!response.IsSuccessStatusCode) return RedirectToAction(nameof(Index)).NotifyBadRequest();
        viewModel.Feature = await response.Content.ReadAsJsonAsync<FeatureDto>();
        return View(viewModel);
      }
      catch (Exception ex)
      {
        return RedirectToAction(nameof(Index)).NotifyError(ex.Message);
      };
    }

    // POST: Features/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(long? id, FeatureViewModel viewModel)
    {
      try
      {

        if (id == null) return RedirectToAction(nameof(Index)).NotifyBadRequest();
        if (id != viewModel.Feature.Id) return RedirectToAction(nameof(Index)).NotifyBadRequest();

        viewModel.PageHeader = new PageHeaderViewModel
        {
          Title = "Features",
          FormName = "editFeatureForm",
          Target = "/admin/features/"
        };

        if (!TryValidateModel(viewModel.Feature)) return View(viewModel).NotifyValidationError();
        var response = await _httpService.Api.PutAsJsonAsync($"/api/features/{id}", viewModel.Feature);
        if (!response.IsSuccessStatusCode) return View(viewModel).NotifyBadRequest();
        return RedirectToAction(nameof(Index)).NotifyUpdated();
      }
      catch (Exception ex)
      {
        return View(viewModel).NotifyError(ex.Message);
      }
    }

    // POST: Features/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int? id)
    {
      try
      {
        if (id == null) return RedirectToAction(nameof(Index)).NotifyBadRequest();
        var response = await _httpService.Api.DeleteAsync($"/api/features/{id}");
        if (!response.IsSuccessStatusCode) return RedirectToAction(nameof(Index)).NotifyBadRequest();
        return RedirectToAction(nameof(Index)).NotifyDeleted();
      }
      catch (Exception ex)
      {
        return RedirectToAction(nameof(Index)).NotifyError(ex.Message);
      };
    }
  }
}