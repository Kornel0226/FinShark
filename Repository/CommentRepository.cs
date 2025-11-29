using FinShark.Data;
using FinShark.Interfaces;
using FinShark.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Repository;

public class CommentRepository(ApplicationDBContext context) : ICommentRepository
{
    public async Task<ICollection<Comment>> GetAllAsync()
    {
        return await context.Comments.ToListAsync();
    }
}