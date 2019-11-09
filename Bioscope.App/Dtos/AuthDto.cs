using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bioscope.Data.Entities;
using Bioscope.Data.Enums;

namespace Bioscope.App.Dtos
{
  public class AuthDto
  {
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(64)]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; }

    [Required]
    [StringLength(255)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(255)]
    public string LastName { get; set; }
    public string Avatar { get; set; }
    public long RoleId { get; set; }
    public bool IsVerified { get; set; }= false;
    public RoleDto Role { get; set; }
    public Status Status { get; set; } = Status.Authorized;
  }
}