using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Data;
using TodoApi.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoItemsController : ControllerBase
{
    private readonly IBaseRepository<TodoItem> _todoItemRepository;

    public TodoItemsController(IBaseRepository<TodoItem> todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    // GET: api/TodoItems
    [HttpGet]
    public IActionResult GetTodoItems()
    {
        return Ok(_todoItemRepository.GetAllAsync());
    }

    // GET: api/TodoItems/5
    // <snippet_GetByID>
    [HttpGet("{id}")]
    public IActionResult GetTodoItem(long id)
    {

        var todoItem = _todoItemRepository.GetByIdAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }
        return Ok(todoItem);

    }
    // </snippet_GetByID>

    // PUT: api/TodoItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Update>
    [HttpPut("{id}")]
    public IActionResult PutTodoItem(long id, TodoItemDTO todoDTO)
    {
        var todoitem = RemoveDTO(todoDTO);
        if (id != todoDTO.Id)
        {
            return BadRequest();
        }
        var todoItem = _todoItemRepository.UpdateByID(id, RemoveDTO(todoDTO));
        if (todoItem == null)
        {
            return NotFound();
        }
        return NoContent();


        /* try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
        {
            return NotFound();
        } */


    }
    // </snippet_Update>

    // POST: api/TodoItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Create>
    [HttpPost]
    public  IActionResult PostTodoItem(TodoItemDTO todoDTO)
    {
        var todoitem = RemoveDTO(todoDTO);
        return Ok(_todoItemRepository.AddAsync(todoitem));
    }
    // </snippet_Create>

    // DELETE: api/TodoItems/5
    [HttpDelete("{id}")]
    public  IActionResult Delete(long id)
    {
       var todoItem = _todoItemRepository.GetByIdAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }
        return NoContent();
    }
    /* public async Task<IActionResult> DeleteTodoItem(long id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    } */

    /* private bool TodoItemExists(long id)
    {
        return _context.TodoItems.Any(e => e.Id == id);
    } */

    private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
       new TodoItemDTO
       {
           Id = todoItem.Id,
           Name = todoItem.Name,
           IsComplete = todoItem.IsComplete
       };
    private static TodoItem RemoveDTO(TodoItemDTO todoitemdto) =>
    new TodoItem
    {
        Id = todoitemdto.Id,
        Name = todoitemdto.Name,
        IsComplete = todoitemdto.IsComplete,
        Category = todoitemdto.Category
    };
}