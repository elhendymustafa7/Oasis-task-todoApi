using Microsoft.AspNetCore.Mvc;
using Oasis_task.Model;
using System.Drawing.Printing;

namespace Oasis_task.Data.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodosAsync(int page, int pageSize);
        //Task<IEnumerable<Todo>> GetAllTodosAsync(int UserId);
        Task<Todo> GetTodoByIdAsync(int id);
        Task CreateTodoAsync(Todo todo);
        Task UpdateTodoAsync(Todo todo);
        Task DeleteTodoAsync(int id);
    }
}
