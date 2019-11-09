using Bioscope.App.Dtos;
using System.Collections.Generic;

namespace Bioscope.App.Areas.Admin.ViewModels
{
    public class RoleViewModel
    {
        public RoleDto Role { get; set; }
        public PageHeaderViewModel PageHeader { get; set; }
        public List<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }
}
