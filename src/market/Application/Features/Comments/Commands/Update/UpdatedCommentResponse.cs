using NArchitecture.Core.Application.Responses;

namespace Application.Features.Comments.Commands.Update;

public class UpdatedCommentResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CommentText { get; set; }
    public DateTime CommentDate { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
}