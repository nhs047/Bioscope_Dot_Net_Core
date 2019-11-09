using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bioscope.Data.Entities
{
  public class State : BaseEntity
  {
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    public long CountryId { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; }
  }
}