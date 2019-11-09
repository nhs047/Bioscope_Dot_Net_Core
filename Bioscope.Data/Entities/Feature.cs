using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bioscope.Data.Enums;

namespace Bioscope.Data.Entities
{
  public class Feature
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [StringLength(512)]
    public string Description { get; set; }

    public int MaxAuthLevel { get; set; } = 0;

    [Column(TypeName="tinyint(1)")]
    public bool IsAuthorizable { get; set; } = false;
    public Status Status { get; set; } = Status.Authorized;

    public virtual List<RoleFeature> RoleFeatures { get; set; }
  }
}