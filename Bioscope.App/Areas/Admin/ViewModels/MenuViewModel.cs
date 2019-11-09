using Bioscope.App.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Bioscope.App.Areas.Admin.ViewModels
{
    public class MenuViewModel
    {
        public MenuDto Menu { get; set; }
        public PageHeaderViewModel PageHeader { get; set; }
        public List<MenuDto> Menus { get; set; } = new List<MenuDto>();
        public IEnumerable<SelectListItem> Features { get; set; } = new List<SelectListItem>();
    }
}
