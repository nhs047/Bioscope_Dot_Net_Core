using System;
using System.ComponentModel.DataAnnotations;
using Bioscope.Data.Enums;

namespace Bioscope.App.Dtos
{
  public class PostCategoryDto
  {
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Status Status { get; set; }

    [Required]
    public long PostId { get; set; }

    [Required]
    public long CategoryId { get; set; }

    public PostDto Post { get; set; }
    
    public CategoryDto Category { get; set; }
  }
}