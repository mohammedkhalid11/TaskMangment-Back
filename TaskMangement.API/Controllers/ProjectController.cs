using Microsoft.AspNetCore.Mvc;
using TaskMangement.Data.Models;
using TaskMangement.Service.IService;

namespace TaskMangement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectService projectService) : ControllerBase
    {
        private readonly IProjectService _projectService = projectService;

        // GET: api/Project
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var project = await _projectService.GetByIdAsync(id);

            if (project == null)
                return NotFound($"لم يتم العثور على المشروع بالـ Id: {id}");

            return Ok(project);
        }

        // POST: api/Project
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _projectService.CreateAsync(project);

            if (created == null)
                return BadRequest("فشلت عملية إضافة المشروع.");

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _projectService.UpdateAsync(id, project);

            if (updated == null)
                return NotFound($"لم يتم العثور على المشروع بالـ Id: {id}");

            return Ok(updated);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _projectService.DeleteAsync(id);

            if (deleted == null)
                return NotFound($"لم يتم العثور على المشروع بالـ Id: {id}");

            return Ok(deleted);
        }
    }
}
