using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bioscope.Data.Enums;

namespace Bioscope.Data.Entities
{
  public class Contact
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; }

    [Required]
    [StringLength(255)]
    public string Subject { get; set; }

    [Required]
    public string Body { get; set; }

    public Status Status { get; set; } = Status.Authorized;
  }
}