using Microsoft.AspNetCore.Mvc;
using TaskMangement.Data.Models;
using TaskMangement.Service.IService;

namespace TaskMangement.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CommentController(ICommentService commentService) : ControllerBase
{
    private readonly ICommentService _commentService = commentService;

    // GET: api/Comments
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentService.GetAllAsync();
        return Ok(comments);
    }

    // GET: api/Comments/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var comment = await _commentService.GetByIdAsync(id);

        if (comment == null)
            return NotFound($"لم يتم العثور على التعليق بالـ Id: {id}");

        return Ok(comment);
    }

    // POST: api/Comments
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Comment comment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _commentService.CreateAsync(comment);

        if (created == null)
            return BadRequest("فشلت عملية إضافة التعليق.");

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT: api/Comments/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] Comment comment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _commentService.UpdateAsync(id, comment);

        if (updated == null)
            return NotFound($"لم يتم العثور على التعليق بالـ Id: {id}");

        return Ok(updated);
    }

    // DELETE: api/Comments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deleted = await _commentService.DeleteAsync(id);

        if (deleted == null)
            return NotFound($"لم يتم العثور على التعليق بالـ Id: {id}");

        return Ok(deleted);
    }
}