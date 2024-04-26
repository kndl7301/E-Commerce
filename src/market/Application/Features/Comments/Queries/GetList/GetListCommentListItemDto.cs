using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Comments.Queries.GetList;

public class GetListCommentListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CommentText { get; set; }
    public DateTime CommentDate { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}