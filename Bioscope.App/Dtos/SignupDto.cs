using System;
using System.ComponentModel.DataAnnotations;
using Bioscope.Data.Enums;

namespace Bioscope.App.Dtos
{
  public class SignupDto
  {

    [Required]
    [StringLength(255)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(255)]
    public string LastName { get; set; }

    [Required]
    [StringLength(64)]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; }

    public long RoleId { get; set; } = (long) UserRole.User;

    [Required]
    [StringLength(32)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [StringLength(32)]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
  }
}