using FinShark.Dtos.Comment;
using FinShark.Models;

namespace FinShark.Mappers;

public static class CommentMapper
{
    public static CommentDto ToCommentDto(this Comment commentModel)
    {
        return new CommentDto
        {
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            StockId = commentModel.StockId,
            CreatedOn = commentModel.CreatedOn
        };
    }
    
    public static Comment ToCommentFromCreateDto(this CreateCommentRequestDto createCommentRequestDto, int stockId)
    {
        return new Comment {
            Title = createCommentRequestDto.Title,
            Content = createCommentRequestDto.Content,
            StockId = stockId
        };
    }
}