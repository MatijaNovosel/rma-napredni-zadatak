using System.ComponentModel.DataAnnotations;

namespace RMA_API.Models
{
  public class TodoItem
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "The description field is required!")]
    [StringLength(maximumLength: 255, MinimumLength = 5)]
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}