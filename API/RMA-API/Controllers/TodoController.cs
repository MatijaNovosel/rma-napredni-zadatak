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
      var newItem = new TodoItem() {
        CreatedAt = DateTime.Now,
        Description = todoItem.Description
      };
      await _dbContext.AddAsync(newItem);
      return newItem.Id;
    }
  }
}