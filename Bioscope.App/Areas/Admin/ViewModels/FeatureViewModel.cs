using Bioscope.App.Dtos;
using System.Collections.Generic;

namespace Bioscope.App.Areas.Admin.ViewModels
{
    public class FeatureViewModel
    {
        public FeatureDto Feature { get; set; }
        public PageHeaderViewModel PageHeader { get; set; }
        public List<FeatureDto> Features { get; set; } = new List<FeatureDto>();
    }
}
