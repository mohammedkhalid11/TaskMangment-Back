using Microsoft.AspNetCore.Mvc;
using TaskMangement.Data.Models;
using TaskMangement.Service.IService;

namespace TaskMangement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController(IPriorityService priorityService) : ControllerBase
    {
        private readonly IPriorityService _priorityService = priorityService;

        // GET: api/Priority
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var priorities = await _priorityService.GetAllAsync();
            return Ok(priorities);
        }

        // GET: api/Priority/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var priority = await _priorityService.GetByIdAsync(id);

            if (priority == null)
                return NotFound($"لم يتم العثور على الأولوية بالـ Id: {id}");

            return Ok(priority);
        }

        // POST: api/Priority
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Priority priority)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _priorityService.CreateAsync(priority);

            if (created == null)
                return BadRequest("فشلت عملية إضافة الأولوية.");

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/Priority/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Priority priority)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _priorityService.UpdateAsync(id, priority);

            if (updated == null)
                return NotFound($"لم يتم العثور على الأولوية بالـ Id: {id}");

            return Ok(updated);
        }

        // DELETE: api/Priority/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _priorityService.DeleteAsync(id);

            if (deleted == null)
                return NotFound($"لم يتم العثور على الأولوية بالـ Id: {id}");

            return Ok(deleted);
        }
    }
}
