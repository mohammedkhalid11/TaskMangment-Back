using Microsoft.AspNetCore.Http;
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

        // GET: api/Genres
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var project = await _projectService.GetAllAsync();
            return Ok(project);
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var project = await _projectService.GetByIdAsync(id);

            if (project == null)
                return NotFound($"لم يتم العثور على Project بالـ Id: {id}");

            return Ok(project);
        }

        // POST: api/Genres
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _projectService.CreateAsync(project);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _projectService.UpdateAsync(id, project);

            if (updated == null)
                return NotFound($"لم يتم العثور على Project بالـ Id: {id}");

            return Ok(updated);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _projectService.DeleteAsync(id);

            if (deleted == null)
                return NotFound($"لم يتم العثور على Project بالـ Id: {id}");

            return Ok(deleted);
        }
    }
}