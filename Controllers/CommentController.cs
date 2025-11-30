using FinShark.Dtos.Comment;
using FinShark.Interfaces;
using FinShark.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.Controllers;

[Route("api/comments")]
[ApiController]
public class CommentController(ICommentRepository commentRepo, IStockRepository stockRepo) : ControllerBase
{
    // GET api/comments ---> Get all comments
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await commentRepo.GetAllAsync();
        
        return Ok(
            comments.Select(c => c.ToCommentDto())
            );
    }
    
    // GET api/comments/{id} ---> Get comment by id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var comment = await commentRepo.GetByIdAsync(id);
        
        if (comment is null) return NotFound();
        
        return Ok(comment.ToCommentDto());
    }

    [HttpPost("{stockId:int}")]
    public async Task<IActionResult> Create(int stockId, CreateCommentRequestDto commentDto)
    {
        if (!await stockRepo.ExistsAsync(stockId)) return NotFound();
        var comment = await commentRepo.CreateAsync(commentDto.ToCommentFromCreateDto(stockId));
        return CreatedAtAction(nameof(GetById), new {id = comment.Id}, comment.ToCommentDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCommentRequestDto commentDto)
    {
        var comment = await commentRepo.UpdateAsync(id, commentDto);
        if (comment is null) return NotFound();
        return Ok(comment.ToCommentDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var comment = await commentRepo.DeleteAsync(id);
        if (comment is null) return NotFound();
        return NoContent();
    }
}