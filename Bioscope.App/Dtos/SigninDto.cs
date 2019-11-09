using System.ComponentModel.DataAnnotations;

namespace Bioscope.App.Dtos
{
  public class SigninDto
  {
    [Required]
    [StringLength(64)]
    public string UserName { get; set; }

    [Required]
    [StringLength(32)]
    public string Password { get; set; }
  }
}