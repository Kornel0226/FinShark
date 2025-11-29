using FinShark.Interfaces;
using FinShark.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.Controllers;

[Route("api/comments")]
[ApiController]
public class CommentController(ICommentRepository commentRepo) : ControllerBase
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
}