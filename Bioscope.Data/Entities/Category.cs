using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bioscope.Data.Entities
{
  public class Category : BaseEntity
  {
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    public virtual List<Post> Posts { get; set; }
  }
}