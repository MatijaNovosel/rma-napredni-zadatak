using System.ComponentModel.DataAnnotations;

namespace RMA_API.Models
{
  public class TodoItem
  {
    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerat‌ed(System.ComponentM‌​odel.DataAnnotations‌​.Schema.DatabaseGeneratedOp‌​tion.None)]
    public int Id { get; set; }
    [Required(ErrorMessage = "The description field is required!")]
    [StringLength(maximumLength: 255, MinimumLength = 5)]
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
  }

  public class TodoItemDto
  {
    [Required(ErrorMessage = "The description field is required!")]
    [StringLength(maximumLength: 255, MinimumLength = 5)]
    public string? Description { get; set; }
  }
}