using System;
using System.ComponentModel.DataAnnotations;
using Bioscope.Data.Enums;

namespace Bioscope.App.Dtos
{
  public class PostDto
  {
    public long Id { get; set; }

    [Required]
    [StringLength(512)]
    public string Title { get; set; }
    public string Description { get; set; }
    public int MaxAuthLevel { get; set; }
    public int AuthLevel { get; set; }

    [Required]
    public long CreatedById { get; set; }
    public long? UpdatedById { get; set; }

    [Required]
    public PostType PostType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Status Status { get; set; }
    public UserDto CreatedBy { get; set; }
    public UserDto UpdatedBy { get; set; }
  }
}