namespace TodoApi.Interfaces;
using TodoApi.Models;


public interface IUnitOfWork : IDisposable
{

    IBaseRepository<TodoItem> TodoItems {get;} 
   int Complete();

}