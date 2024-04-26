using Application.Features.Ratings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Ratings.Constants.RatingsOperationClaims;

namespace Application.Features.Ratings.Queries.GetList;

public class GetListRatingQuery : IRequest<GetListResponse<GetListRatingListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListRatings({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetRatings";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRatingQueryHandler : IRequestHandler<GetListRatingQuery, GetListResponse<GetListRatingListItemDto>>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public GetListRatingQueryHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRatingListItemDto>> Handle(GetListRatingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Rating> ratings = await _ratingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRatingListItemDto> response = _mapper.Map<GetListResponse<GetListRatingListItemDto>>(ratings);
            return response;
        }
    }
}