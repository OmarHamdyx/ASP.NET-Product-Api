using TodoApi.Interfaces;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Repositories;
namespace TodoApi.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly TodoContext _context;
    IBaseRepository<TodoItem> TodoItems { get; set; }


    public UnitOfWork(TodoContext context)
    {
        _context = context;
        TodoItems = new BaseRepository<TodoItem>(_context);

    }


    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();

    }

}