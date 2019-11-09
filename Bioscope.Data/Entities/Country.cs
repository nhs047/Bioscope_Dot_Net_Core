using System.ComponentModel.DataAnnotations;

namespace Bioscope.Data.Entities
{
  public class Country : BaseEntity
  {
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
  }
}