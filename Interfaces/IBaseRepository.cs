
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
namespace TodoApi.Interfaces;


public interface IBaseRepository<T> where T : class
{

    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(long id);
    Task<T> UpdateByID(long id, T modifiedEntity);
    Task<T> Delete(long id);
    Task AddAsync(T entity);



}