namespace RMA_API.Models
{
  public class TodoItem
  {
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}