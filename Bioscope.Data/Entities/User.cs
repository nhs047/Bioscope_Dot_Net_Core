using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bioscope.Data.Enums;

namespace Bioscope.Data.Entities
{
  public class User
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    public byte[] PasswordHash { get; set; }

    [Required]
    public byte[] PasswordSalt { get; set; }

    [Required]
    [StringLength(255)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(255)]
    public string LastName { get; set; }
    public string Avatar { get; set; }
    public long RoleId { get; set; }

    public string VericationCode { get; set; }
    
    [Column(TypeName="tinyint(1)")]
    public bool IsVerified { get; set; }= false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; }
    public Status Status { get; set; } = Status.Authorized;
    public virtual List<Post> Posts { get; set; }
  }
}