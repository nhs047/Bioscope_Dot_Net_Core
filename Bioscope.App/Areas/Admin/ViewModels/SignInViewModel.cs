using System.ComponentModel.DataAnnotations;

namespace Bioscope.App.Areas.Admin.ViewModels
{
  public class SignInViewModel
  {
    [Required]
    [Display(Name = "Username")]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }    
  }
}