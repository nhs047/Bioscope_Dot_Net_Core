using System.ComponentModel.DataAnnotations;

namespace Bioscope.Data.Entities
{
  public class AuthLog : BaseEntity
  {
    [Required]
    public long RefId { get; set; }

    [Required]
    [StringLength(255)]
    public string Model { get; set; }

  }
}