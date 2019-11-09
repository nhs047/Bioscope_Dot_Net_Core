using System;
using System.ComponentModel.DataAnnotations;
using Bioscope.Data.Enums;

namespace Bioscope.App.Dtos
{
  public class CountryDto
  {
    public long Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Status Status { get; set; }
  }
}