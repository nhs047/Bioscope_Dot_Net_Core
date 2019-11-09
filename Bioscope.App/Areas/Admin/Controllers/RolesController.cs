using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bioscope.App.Areas.Admin.ViewModels;
using Bioscope.App.Dtos;
using Bioscope.App.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Bioscope.App.Areas.Admin.Controllers
{
    [Area("Admin")]
  public class RolesController : Controller
  {
    private readonly HttpService _httpService;
    public RolesController(HttpService httpService)
    {
      _httpService = httpService;
    }

    // GET: Roles
    public async Task<IActionResult> Index(RoleViewModel viewModel)
    {
      try
      {
        viewModel.PageHeader = new PageHeaderViewModel
        {
          Title = "Roles",
          PageLink = "/admin/roles/",
          CreatePage = "/admin/roles/create"
        };
        var response = await _httpService.Api.GetAsync("/api/roles");
        if (!response.IsSuccessStatusCode) return RedirectToAction("Index", "Home").NotifyBadRequest();
        viewModel.Roles = await response.Content.ReadAsJsonAsync<List<RoleDto>>();
        return View(viewModel);
      }
      catch (Exception ex)
      {
        return RedirectToAction("Index", "Home").NotifyError(ex.Message);
      }
    }

    // GET: Roles/Details/5
    public async Task<ActionResult> Details(long? id)
    {
      try
      {
        if (id == null) return RedirectToAction(nameof(Index));
        var viewModel = new RoleViewModel
        {
          PageHeader = new PageHeaderViewModel
          {
            Title = "Role Details",
            PageLink = $"/admin/roles/details/{id}",
            Target = "/admin/roles/",
            CreatePage = "/admin/roles/create"
          }
        };

        var response = await _httpService.Api.GetAsync($"/api/roles/{id}");
        if (!response.IsSuccessStatusCode) return RedirectToAction(nameof(Index)).NotifyBadRequest();
        viewModel.Role = await response.Content.ReadAsJsonAsync<RoleDto>();
        return View(viewModel);
      }
      catch (Exception ex)
      {
        return RedirectToAction(nameof(Index)).NotifyError(ex.Message);
      }
    }

    // GET: Roles/Create
    public ActionResult Create()
    {
      var vm = new RoleViewModel
      {
        PageHeader = new PageHeaderViewModel
        {
          Title = "Add New Role",
          FormName = "addRoleForm",
          Target = "/admin/roles/"
        }
      };
      return View(vm);
    }

    // POST: Roles/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(RoleViewModel viewModel)
    {
      try
      {
        viewModel.PageHeader = new PageHeaderViewModel
        {
          Title = "Roles",
          FormName = "addRoleForm",
          Target = "/admin/roles/"
        };
        if (!TryValidateModel(viewModel.Role)) return View(viewModel).NotifyValidationError();
        var response = await _httpService.Api.PostAsJsonAsync("/api/roles", viewModel.Role);
        if (!response.IsSuccessStatusCode) return View(viewModel).NotifyBadRequest();
        return RedirectToAction(nameof(Index)).NotifySaved();
      }
      catch(Exception ex)
      {
        return View(viewModel).NotifyError(ex.Message);
      }
    }

    // GET: Roles/Edit/5
    public async Task<ActionResult> Edit(long? id)
    {
      try
      {
        if (id == null) return RedirectToAction(nameof(Index)).NotifyBadRequest();
        var viewModel = new RoleViewModel
        {
          PageHeader = new PageHeaderViewModel
          {
          Title = "Edit Role",
          FormName = "editRoleForm",
          Target = "/admin/roles/"
          }
        };
        var response = await _httpService.Api.GetAsync($"/api/roles/{id}");
        if (!response.IsSuccessStatusCode) return RedirectToAction(nameof(Index)).NotifyBadRequest();
        viewModel.Role = await response.Content.ReadAsJsonAsync<RoleDto>();
        return View(viewModel);
      }
      catch (Exception ex)
      {
        return RedirectToAction(nameof(Index)).NotifyError(ex.Message);
      };
    }

    // POST: Roles/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(long? id, RoleViewModel viewModel)
    {
      try
      {

        if (id == null) return RedirectToAction(nameof(Index)).NotifyBadRequest();
        if (id != viewModel.Role.Id) return RedirectToAction(nameof(Index)).NotifyBadRequest();

        viewModel.PageHeader = new PageHeaderViewModel
        {
          Title = "Roles",
          FormName = "editRoleForm",
          Target = "/admin/roles/"
        };

        if (!TryValidateModel(viewModel.Role)) return View(viewModel).NotifyValidationError();
        var response = await _httpService.Api.PutAsJsonAsync($"/api/roles/{id}", viewModel.Role);
        if (!response.IsSuccessStatusCode) return View(viewModel).NotifyBadRequest();
        return RedirectToAction(nameof(Index)).NotifyUpdated();
      }
      catch(Exception ex)
      {
        return View(viewModel).NotifyError(ex.Message);
      }
    }

    // POST: Roles/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int? id)
    {
      try
      {
        if (id == null) return RedirectToAction(nameof(Index)).NotifyBadRequest();
        var response = await _httpService.Api.DeleteAsync($"/api/roles/{id}");
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