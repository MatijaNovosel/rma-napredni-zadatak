using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMA_API.Models
{
  public class TodoItem
  {
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "The text field is required!")]
    [MaxLength(255)]
    [MinLength(5)]
    [Column(TypeName = "varchar(255)")]
    public string? Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Done { get; set; }
  }

  public class TodoItemDto
  {
    [Required(ErrorMessage = "The text field is required!")]
    [MaxLength(255)]
    [MinLength(5)]
    public string? Text { get; set; }
  }
}