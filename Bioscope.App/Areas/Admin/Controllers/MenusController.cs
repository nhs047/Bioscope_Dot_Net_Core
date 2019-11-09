using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bioscope.App.Areas.Admin.ViewModels;
using Bioscope.App.Dtos;
using Bioscope.App.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bioscope.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenusController : Controller
    {
        private readonly HttpService _httpService;
        public MenusController(HttpService httpService)
        {
            _httpService = httpService;
        }

        // GET: Menus
        public async Task<IActionResult> Index(MenuViewModel viewModel)
        {
            try
            {
                viewModel.PageHeader = new PageHeaderViewModel
                {
                    Title = "Menus",
                    PageLink = "/admin/menus/",
                    CreatePage = "/admin/menus/create"
                };
                var response = await _httpService.Api.GetAsync("/api/menus");
                if (!response.IsSuccessStatusCode) return RedirectToAction("Index", "Home").NotifyBadRequest();
                viewModel.Menus = await response.Content.ReadAsJsonAsync<List<MenuDto>>();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home").NotifyError(ex.Message);
            }
        }

        // GET: Menus/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            try
            {
                if (id == null) return RedirectToAction(nameof(Index));
                var viewModel = new MenuViewModel
                {
                    PageHeader = new PageHeaderViewModel
                    {
                        Title = "Menu Details",
                        PageLink = $"/admin/menus/details/{id}",
                        Target = "/admin/menus/",
                        CreatePage = "/admin/menus/create"
                    }
                };

                var response = await _httpService.Api.GetAsync($"/api/menus/{id}");
                if (!response.IsSuccessStatusCode) return RedirectToAction(nameof(Index)).NotifyBadRequest();
                viewModel.Menu = await response.Content.ReadAsJsonAsync<MenuDto>();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index)).NotifyError(ex.Message);
            }
        }

        // GET: Menus/Create
        public async Task<ActionResult> Create()
        {
            var viewModel = new MenuViewModel
            {
                PageHeader = new PageHeaderViewModel
                {
                    Title = "Add New Menu",
                    FormName = "addMenuForm",
                    Target = "/admin/menus/"
                }
            };
            var response = await _httpService.Api.GetAsync("/api/dropdown/features");
            if (!response.IsSuccessStatusCode) return View(viewModel).NotifyBadRequest();
            viewModel.Features = await response.Content.ReadAsJsonAsync<IEnumerable<SelectListItem>>();
            return View(viewModel);
        }

        // POST: Menus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MenuViewModel viewModel)
        {
            try
            {
                viewModel.PageHeader = new PageHeaderViewModel
                {
                    Title = "Menus",
                    FormName = "addMenuForm",
                    Target = "/admin/menus/"
                };
                if (!TryValidateModel(viewModel.Menu)) return View(viewModel).NotifyValidationError();
                var response = await _httpService.Api.PostAsJsonAsync("/api/menus", viewModel.Menu);
                if (!response.IsSuccessStatusCode) return View(viewModel).NotifyBadRequest();
                return RedirectToAction(nameof(Index)).NotifySaved();
            }
            catch (Exception ex)
            {
                return View(viewModel).NotifyError(ex.Message);
            }
        }

        // GET: Menus/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            try
            {
                if (id == null) return RedirectToAction(nameof(Index)).NotifyBadRequest();
                var viewModel = new MenuViewModel
                {
                    PageHeader = new PageHeaderViewModel
                    {
                        Title = "Edit Menu",
                        FormName = "editMenuForm",
                        Target = "/admin/menus/"
                    }
                };
                var response = await _httpService.Api.GetAsync($"/api/menus/{id}");
                if (!response.IsSuccessStatusCode) return RedirectToAction(nameof(Index)).NotifyBadRequest();
                viewModel.Menu = await response.Content.ReadAsJsonAsync<MenuDto>();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index)).NotifyError(ex.Message);
            };
        }

        // POST: Menus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long? id, MenuViewModel viewModel)
        {
            try
            {

                if (id == null) return RedirectToAction(nameof(Index)).NotifyBadRequest();
                if (id != viewModel.Menu.Id) return RedirectToAction(nameof(Index)).NotifyBadRequest();

                viewModel.PageHeader = new PageHeaderViewModel
                {
                    Title = "Menus",
                    FormName = "editMenuForm",
                    Target = "/admin/menus/"
                };

                if (!TryValidateModel(viewModel.Menu)) return View(viewModel).NotifyValidationError();
                var response = await _httpService.Api.PutAsJsonAsync($"/api/menus/{id}", viewModel.Menu);
                if (!response.IsSuccessStatusCode) return View(viewModel).NotifyBadRequest();
                return RedirectToAction(nameof(Index)).NotifyUpdated();
            }
            catch (Exception ex)
            {
                return View(viewModel).NotifyError(ex.Message);
            }
        }

        // POST: Menus/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null) return RedirectToAction(nameof(Index)).NotifyBadRequest();
                var response = await _httpService.Api.DeleteAsync($"/api/menus/{id}");
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