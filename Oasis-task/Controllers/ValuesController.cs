using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oasis_task.Services;

namespace Oasis_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly TodoApiService _todoApiService;

        public ValuesController(TodoApiService todoApiService)
        {
            _todoApiService = todoApiService;
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportTodosFromApi()
        {
            await _todoApiService.ImportTodosFromApiAsync();
            return Ok("Todos imported and saved in the database.");
        }
    }
}
