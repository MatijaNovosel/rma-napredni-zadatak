using Microsoft.AspNetCore.Mvc;
using RMA_API.Models;

namespace RMA_API.Controllers
{
  [ApiController]
  [Route("")]
  public class WeatherForecastController : ControllerBase
  {
    [HttpGet]
    public IEnumerable<TodoItem> Get()
    {
      return Enumerable.Range(1, 5).Select(index => new TodoItem
      {
        Id = index,
        Description = $"Todo item {index}",
        CreatedAt = DateTime.Now.AddDays(index)
      })
      .ToArray();
    }
  }
}