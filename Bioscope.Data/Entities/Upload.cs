using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bioscope.Data.Entities
{
  public class Upload : BaseEntity
  {
    public long PostId { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [StringLength(255)]
    public string Link { get; set; }

    [Required]
    [StringLength(255)]
    public string FileType { get; set; }

    [Required]
    public double FileSize { get; set; }

    [Required]
    [StringLength(50)]
    public string Resolution { get; set; }

    [Required]
    [StringLength(255)]
    public string FileOwner { get; set; }

    public TimeSpan? Duration { get; set; }

    public string Address1 { get; set; }
    public string Address2 { get; set; }

    public long? CityId { get; set; }

    public long? StateId { get; set; }

    public long? CountryId { get; set; }

    [ForeignKey("PostId")]
    public virtual Post Post { get; set; }

    [ForeignKey("CityId")]
    public virtual City City { get; set; }

    [ForeignKey("StateId")]
    public virtual State State { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; }
  }
}