using Microsoft.AspNetCore.Mvc;
using RMA_API.Models;
using RMA_API.Context;

namespace RMA_API.Controllers
{
  [ApiController]
  [Route("")]
  public class TodoController : ControllerBase
  {
    protected readonly TodoContext _dbContext;

    public TodoController(TodoContext dbContext)
    {
      _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    [HttpGet]
    public List<TodoItem> Get()
    {
      return _dbContext.TodoItems.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(TodoItemDto todoItem)
    {
      var newItem = new TodoItem()
      {
        CreatedAt = DateTime.Now,
        Text = todoItem.Text,
        Done = false
      };
      await _dbContext.TodoItems.AddAsync(newItem);
      await _dbContext.SaveChangesAsync();
      return Ok(newItem.Id);
    }

    [HttpPost("mark-as-done")]
    public async Task<ActionResult> MarkAsDone(int id)
    {
      var todoItem = _dbContext.TodoItems.FirstOrDefault(item => item.Id == id);

      if (todoItem != null)
      {
        todoItem.Done = true;
        await _dbContext.SaveChangesAsync();
        return Ok($"Todo item with the id of {id} marked as done!");
      }
      else
      {
        return NotFound($"Todo item with the id of {id} does not exist!");
      }
    }
  }
}