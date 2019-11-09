using System.ComponentModel.DataAnnotations;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;

namespace Bioscope.App.Dtos
{
  public class MenuDto
  {
    public long Id { get; set; }

    public long FeatureId { get; set; }

    [Required]
    [StringLength(255)]
    public string CodeName { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [StringLength(255)]
    public string GroupName { get; set; }

    [Required]
    public string RouteLink { get; set; }

    public Status Status { get; set; }
    public virtual FeatureDto Feature { get; set; }
  }
}