using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bioscope.Data.Enums;

namespace Bioscope.Data.Entities
{
  public class Staff : BaseEntity
  {
    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; }

    [Required]
    [StringLength(255)]
    public string Address1 { get; set; }

    [StringLength(255)]
    public string Address2 { get; set; }

    [Required]
    public long CityId { get; set; }

    [Required]
    public long StateId { get; set; }

    [Required]
    public long CountryId { get; set; }

    [Required]
    [StringLength(20)]
    public string Phone { get; set; }
    public long? UserId { get; set; }
    public StaffType StaffType { get; set; }

    [ForeignKey("CityId")]
    public virtual City City { get; set; }

    [ForeignKey("StateId")]
    public virtual State State { get; set; }

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }
  }
}