using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bioscope.Data.Entities
{
  public class RoleFeature : BaseEntity
  {
    [Required]
    public long RoleId { get; set; }

    [Required]
    public long FeatureId { get; set; }

    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; }

    [ForeignKey("FeatureId")]
    public virtual Feature Feature { get; set; }
  }
}