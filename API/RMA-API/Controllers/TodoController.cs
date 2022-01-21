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
    public async Task<int> Create(TodoItemDto todoItem)
    {
      var newItem = new TodoItem()
      {
        CreatedAt = DateTime.Now,
        Description = todoItem.Description
      };
      await _dbContext.TodoItems.AddAsync(newItem);
      await _dbContext.SaveChangesAsync();
      return newItem.Id;
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
      var todoItem = _dbContext.TodoItems.FirstOrDefault(item => item.Id == id);

      if (todoItem != null)
      {
        _dbContext.TodoItems.Remove(todoItem);
        await _dbContext.SaveChangesAsync();
        return Ok($"Todo item with the id of {id} deleted!");
      }
      else
      {
        return NotFound($"Todo item with the id of {id} does not exist!");
      }
    }
  }
}