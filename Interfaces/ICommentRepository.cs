using FinShark.Models;

namespace FinShark.Interfaces;

public interface ICommentRepository
{
    Task<ICollection<Comment>> GetAllAsync();
}