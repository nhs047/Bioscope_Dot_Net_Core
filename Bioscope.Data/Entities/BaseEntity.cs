using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bioscope.Data.Enums;

namespace Bioscope.Data.Entities
{
  public abstract class BaseEntity
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [Required]
    public long CreatedById { get; set; }
    public long? UpdatedById { get; set; }
    public Status Status { get; set; } = Status.Pending;

    [ForeignKey("CreatedById")]
    public virtual User CreatedBy { get; set; }

    [ForeignKey("UpdatedById")]
    public virtual User UpdatedBy { get; set; }
  }
}