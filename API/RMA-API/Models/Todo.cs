using System.ComponentModel.DataAnnotations;

namespace RMA_API.Models
{
  public class TodoItem
  {
    public int Id { get; set; }
    [Required]
    [MaxLength(255)]
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}