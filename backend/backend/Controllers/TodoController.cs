using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            try
            {
                var todos = await _todoRepository.GetAllTodosAsync();
                if (todos == null)
                {
                    return NotFound();
                }
                return Ok(todos);
            }
            catch
            {
                return StatusCode(500, "An error occurred while retrieving todos.");
            }
        }

        [HttpGet("{category}")]
        public async Task<IActionResult> GetTodoByCategory(string category)
        {
            try
            {
                var todos = await _todoRepository.GetTodoByCategoryAsync(category);
                if (todos == null)
                {
                    return NotFound();
                }
                return Ok(todos);
            }
            catch
            {
                return StatusCode(500, "An error occurred while retrieving todos by category.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] Todo todo)
        {
            try
            {
                var res = await _todoRepository.AddTodoAsync(todo);
                if (res <= 0)
                {
                    return BadRequest("Failed to add todo");
                }
                return Ok();
            }
            catch
            {
                return StatusCode(500, "An error occurred while adding the todo.");
            }
        }
    }
}
