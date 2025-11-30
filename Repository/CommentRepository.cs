using FinShark.Data;
using FinShark.Dtos.Comment;
using FinShark.Interfaces;
using FinShark.Mappers;
using FinShark.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Repository;

public class CommentRepository(ApplicationDBContext context) : ICommentRepository
{
    public async Task<ICollection<Comment>> GetAllAsync()
    {
        return await context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == id);

        return comment;
    }

    public async Task<Comment> CreateAsync(Comment commentObject)
    {
        await context.Comments.AddAsync(commentObject);
        await context.SaveChangesAsync();
        return commentObject;
    }

    public async Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto commentDto)
    {
        var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        
        if (comment is null) return null;
        
        comment.Title = commentDto.Title;
        comment.Content = commentDto.Content;
        
        await context.SaveChangesAsync();
        
        return comment;
        
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
        var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (comment is null) return null;
        
        context.Comments.Remove(comment);
        await context.SaveChangesAsync();
        
        return comment;
    }
}