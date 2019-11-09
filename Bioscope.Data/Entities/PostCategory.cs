using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bioscope.Data.Entities
{
  public class PostCategory : BaseEntity
  {
    [Required]
    public long PostId { get; set; }

    [Required]
    public long CategoryId { get; set; }

    [ForeignKey("PostId")]
    public virtual Post Post { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
  }
}