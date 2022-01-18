using Microsoft.AspNetCore.Mvc;
using RMA_API.Models;

namespace RMA_API.Controllers
{
  [ApiController]
  [Route("")]
  public class TodoController : ControllerBase
  {
    [HttpGet]
    public IEnumerable<TodoItem> Get()
    {
      return Enumerable.Range(1, 5).Select(index => new TodoItem
      {
        Id = index,
        Description = $"Todo item {index}"
      })
      .ToArray();
    }
  }
}