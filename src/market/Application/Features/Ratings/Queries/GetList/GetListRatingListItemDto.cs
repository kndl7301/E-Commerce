using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Ratings.Queries.GetList;

public class GetListRatingListItemDto : IDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Score { get; set; }
}