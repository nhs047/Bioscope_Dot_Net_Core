using System.ComponentModel.DataAnnotations;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;

namespace Bioscope.App.Dtos
{
  public class CityDto
  {
    public long Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    public long CountryId { get; set; }
    public long CreatedById { get; set; }
    public long? UpdatedById { get; set; }
    public Status Status { get; set; }
    public Country Country { get; set; }
    public User CreatedBy { get; set; }
    public User UpdatedBy { get; set; }
  }
}