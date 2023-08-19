using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oasis_task.Authentication;
using Oasis_task.Data;
using Oasis_task.Model;

namespace Oasis_task.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _dbContext;
        public TodosController(IUnitOfWork unitOfWork,ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllTodos")]
        public async Task<IActionResult> GetAllTodos(int page, int pageSize)
        {

            var todos = await _unitOfWork.TodoRepository.GetAllTodosAsync(page, pageSize);
            return Ok(todos);
        }
        [HttpPost("addTodo")] 
        public async Task<IActionResult> CreateTodoAsync(Todo todo)
        {
            _dbContext.Todo.Add(todo);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction("GetTodoById", new { Id = todo.Id }, todo);

        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Todo>> GetTodoById(int id)
        {
            var todo = await _unitOfWork.TodoRepository.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(int id, Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }
            await _unitOfWork.TodoRepository.UpdateTodoAsync(todo);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
           await _unitOfWork.TodoRepository.DeleteTodoAsync(id);
            return Ok();
        }
    }
}
