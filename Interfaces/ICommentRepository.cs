using FinShark.Dtos.Comment;
using FinShark.Models;

namespace FinShark.Interfaces;

public interface ICommentRepository
{
    Task<ICollection<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(int id);
    Task<Comment> CreateAsync(Comment comment);
    Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto commentDto);
    public Task<Comment?> DeleteAsync(int id);
}