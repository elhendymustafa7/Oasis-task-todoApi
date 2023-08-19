using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oasis_task.Model;
using System;


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Oasis_task.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TodoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<IEnumerable<Todo>> GetAllTodosAsync(int UserId)
        public async Task<IEnumerable<Todo>> GetAllTodosAsync(int page, int pageSize)
        {

            return await _dbContext.Todo.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            //return await _dbContext.Todo.Where(x => x.UserId == UserId).ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            return await _dbContext.Todo.FindAsync(id);
        }

        public async Task CreateTodoAsync(Todo todo)
        {
             _dbContext.Todo.Add(todo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            _dbContext.Entry(todo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _dbContext.Todo.FindAsync(id);
            if (todo != null)
            {
                _dbContext.Todo.Remove(todo);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
