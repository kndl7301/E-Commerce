using NArchitecture.Core.Application.Responses;

namespace Application.Features.Ratings.Commands.Create;

public class CreatedRatingResponse : IResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Score { get; set; }
}