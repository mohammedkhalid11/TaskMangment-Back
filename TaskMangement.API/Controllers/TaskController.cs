using Microsoft.AspNetCore.Mvc;
using TaskMangement.Service.IService;

namespace TaskMangement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(IITaskService taskService) : ControllerBase
    {
        private readonly IITaskService _taskService = taskService;

        // GET: api/Tasks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Tasks = await _taskService.GetAllAsync();
            return Ok(Tasks);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var Task = await _taskService.GetByIdAsync(id);

            if (Task == null)
                return NotFound($"لم يتم العثور على التعليق بالـ Id: {id}");

            return Ok(Task);
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Data.Models.Task Task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _taskService.CreateAsync(Task);

            if (created == null)
                return BadRequest("فشلت عملية إضافة التعليق.");

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Data.Models.Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _taskService.UpdateAsync(id, task);

            if (updated == null)
                return NotFound($"لم يتم العثور على التعليق بالـ Id: {id}");

            return Ok(updated);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _taskService.DeleteAsync(id);

            if (deleted == null)
                return NotFound($"لم يتم العثور على التعليق بالـ Id: {id}");

            return Ok(deleted);
        }

    }
}