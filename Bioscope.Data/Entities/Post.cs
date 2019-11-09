using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bioscope.Data.Enums;

namespace Bioscope.Data.Entities
{
  public class Post : BaseEntity
  {
    [Required]
    [StringLength(512)]
    public string Title { get; set; }
    public string Description { get; set; }
    public int MaxAuthLevel { get; set; } = 0;
    public int AuthLevel { get; set; } = 0;

    [Required]
    public PostType PostType { get; set; }
  }
}