using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bioscope.Data.Enums;

namespace Bioscope.Data.Entities
{
  public class Role
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    public int AuthLevel { get; set; } = 0;
    public Status Status { get; set; } = Status.Authorized;
    public virtual List<RoleFeature> RoleFeatures { get; set; }
  }
}