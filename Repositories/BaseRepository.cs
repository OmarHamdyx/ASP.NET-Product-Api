using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TodoApi.Interfaces;
using TodoApi.Data;
using TodoApi.Models;


namespace TodoApi.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly TodoContext _context;

    public BaseRepository(TodoContext context)
    {
        _context = context;

    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(long id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public async Task<T> UpdateByID(long id, T modifiedEntity)
    {
        T item = _context.Set<T>().Find(id);

        _context.Update(modifiedEntity);
        await _context.SaveChangesAsync();

        return item;
    }

    public async Task<T> Delete(long id)
    {
        T item =  _context.Set<T>().Find(id);
        _context.Remove(item);
        await _context.SaveChangesAsync();
        return item;
    }
    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }





















    private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
           new TodoItemDTO
           {
               Id = todoItem.Id,
               Name = todoItem.Name,
               IsComplete = todoItem.IsComplete
           };

}