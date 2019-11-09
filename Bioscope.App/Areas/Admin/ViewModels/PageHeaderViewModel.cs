using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscope.App.Areas.Admin.ViewModels
{
    public class PageHeaderViewModel
    {
        public string Title { get; set; }
        public string PageLink { get; set; }
        public string Target { get; set; }
        public string FormName { get; set; }
        public string CreatePage { get; set; }
    }
}
