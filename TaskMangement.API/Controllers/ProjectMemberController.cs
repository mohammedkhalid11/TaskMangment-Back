using Microsoft.AspNetCore.Mvc;
using TaskMangement.Data.DTOs;
using TaskMangement.Data.Models;
using TaskMangement.Service.IService;

namespace TaskMangement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectMemberController(IProjectMemberService projectMemberService) : ControllerBase
    {
        private readonly IProjectMemberService _projectMemberService = projectMemberService;

        // GET: api/ProjectMember
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projectMembers = await _projectMemberService.GetAllAsync();
            return Ok(projectMembers);
        }

        // GET: api/ProjectMember/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var projectMember = await _projectMemberService.GetByIdAsync(id);

            if (projectMember == null)
                return NotFound($"لم يتم العثور على العضو بالـ Id: {id}");

            return Ok(projectMember);
        }

        // POST: api/ProjectMember
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectMemberDto projectMember)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _projectMemberService.CreateAsync(projectMember);

            if (created == null)
                return BadRequest("فشلت عملية إضافة العضو.");

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/ProjectMember/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] ProjectMember projectMember)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _projectMemberService.UpdateAsync(id, projectMember);

            if (updated == null)
                return NotFound($"لم يتم العثور على العضو بالـ Id: {id}");

            return Ok(updated);
        }

        // DELETE: api/ProjectMember/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _projectMemberService.DeleteAsync(id);

            if (deleted == null)
                return NotFound($"لم يتم العثور على العضو بالـ Id: {id}");

            return Ok(deleted);
        }
    }
}
