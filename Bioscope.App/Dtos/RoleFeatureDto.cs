using System;
using System.ComponentModel.DataAnnotations;
using Bioscope.Data.Enums;

namespace Bioscope.App.Dtos
{
  public class RoleFeatureDto
  {
    public long Id { get; set; }

    [Required]
    public long RoleId { get; set; }

    [Required]
    public long FeatureId { get; set; }
    public RoleDto Role { get; set; }
    public FeatureDto Feature { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Status Status { get; set; }
  }
}