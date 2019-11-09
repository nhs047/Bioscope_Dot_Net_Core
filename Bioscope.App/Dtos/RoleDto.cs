using System.ComponentModel.DataAnnotations;
using Bioscope.Data.Enums;

namespace Bioscope.App.Dtos
{
  public class RoleDto
  {
    public long Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    public int AuthLevel { get; set; } = 0;
    public Status Status { get; set; }
  }
}