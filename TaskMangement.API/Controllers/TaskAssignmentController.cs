using Microsoft.AspNetCore.Mvc;
using TaskMangement.Data.DTOs;
using TaskMangement.Data.Models;
using TaskMangement.Service.IService;

namespace TaskMangement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController(ITaskAssignmentService taskAssignmentService) : ControllerBase
    {
        private readonly ITaskAssignmentService _taskAssignmentService = taskAssignmentService;

        // GET: api/TaskAssignment
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var taskAssignments = await _taskAssignmentService.GetAllAsync();
            return Ok(taskAssignments);
        }

        // GET: api/TaskAssignment/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var taskAssignment = await _taskAssignmentService.GetByIdAsync(id);

            if (taskAssignment == null)
                return NotFound($"لم يتم العثور على التكليف بالـ Id: {id}");

            return Ok(taskAssignment);
        }

        // POST: api/TaskAssignment
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskAssignmentDto taskAssignment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _taskAssignmentService.CreateAsync(taskAssignment);

            if (created == null)
                return BadRequest("فشلت عملية إضافة التكليف.");

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/TaskAssignment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] TaskAssignment taskAssignment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _taskAssignmentService.UpdateAsync(id, taskAssignment);

            if (updated == null)
                return NotFound($"لم يتم العثور على التكليف بالـ Id: {id}");

            return Ok(updated);
        }

        // DELETE: api/TaskAssignment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _taskAssignmentService.DeleteAsync(id);

            if (deleted == null)
                return NotFound($"لم يتم العثور على التكليف بالـ Id: {id}");

            return Ok(deleted);
        }
    }
}

