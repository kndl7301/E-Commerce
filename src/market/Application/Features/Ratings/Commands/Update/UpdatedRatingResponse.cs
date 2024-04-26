using NArchitecture.Core.Application.Responses;

namespace Application.Features.Ratings.Commands.Update;

public class UpdatedRatingResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Score { get; set; }
}