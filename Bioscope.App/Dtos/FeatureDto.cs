using System.ComponentModel.DataAnnotations;
using Bioscope.Data.Enums;

namespace Bioscope.App.Dtos
{
    public class FeatureDto
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Feature Name")]
        public string Name { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        [Display(Name = "Max Auth Level")]
        public int MaxAuthLevel { get; set; }

        [Display(Name = "Authorizable")]
        public bool IsAuthorizable { get; set; }
        public Status Status { get; set; }
    }
}