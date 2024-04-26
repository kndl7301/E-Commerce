using NArchitecture.Core.Application.Responses;

namespace Application.Features.Ratings.Commands.Delete;

public class DeletedRatingResponse : IResponse
{
    public int Id { get; set; }
}