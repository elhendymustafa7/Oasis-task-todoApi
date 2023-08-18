using Microsoft.AspNetCore.Mvc;
using Oasis_task.Model;

namespace Oasis_task.Data.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        //Task<IEnumerable<Todo>> GetAllTodosAsync(int UserId);
        Task<Todo> GetTodoByIdAsync(int id);
        Task CreateTodoAsync(Todo todo);
        Task UpdateTodoAsync(Todo todo);
        Task DeleteTodoAsync(int id);
    }
}
