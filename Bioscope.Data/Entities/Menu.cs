using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bioscope.Data.Enums;

namespace Bioscope.Data.Entities
{
  public class Menu
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public long Id { get; set; }

    [Required]
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

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Status Status { get; set; } = Status.Authorized;

    [ForeignKey("FeatureId")]
    public virtual Feature Feature { get; set; }

  }
}