using Microsoft.AspNetCore.Mvc;
using Lab11.Models;

namespace Lab11.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private static List<TodoItem> _todos = new List<TodoItem>();
        private static int _nextId = 1;

        // GET: api/todo
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll()
        {
            return Ok(_todos);
        }

        // GET: api/todo/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // POST: api/todo
        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem todo)
        {
            todo.Id = _nextId++;
            todo.CreatedDate = DateTime.Now;
            _todos.Add(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        // PUT: api/todo/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem todo)
        {
            var existingTodo = _todos.FirstOrDefault(t => t.Id == id);
            if (existingTodo == null)
            {
                return NotFound();
            }

            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.IsComplete = todo.IsComplete;

            return NoContent();
        }

        // DELETE: api/todo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _todos.Remove(todo);
            return NoContent();
        }
    }
} 