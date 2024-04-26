using Application.Features.Ratings.Constants;
using Application.Features.Ratings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Ratings.Constants.RatingsOperationClaims;

namespace Application.Features.Ratings.Queries.GetById;

public class GetByIdRatingQuery : IRequest<GetByIdRatingResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdRatingQueryHandler : IRequestHandler<GetByIdRatingQuery, GetByIdRatingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;
        private readonly RatingBusinessRules _ratingBusinessRules;

        public GetByIdRatingQueryHandler(IMapper mapper, IRatingRepository ratingRepository, RatingBusinessRules ratingBusinessRules)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _ratingBusinessRules = ratingBusinessRules;
        }

        public async Task<GetByIdRatingResponse> Handle(GetByIdRatingQuery request, CancellationToken cancellationToken)
        {
            Rating? rating = await _ratingRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _ratingBusinessRules.RatingShouldExistWhenSelected(rating);

            GetByIdRatingResponse response = _mapper.Map<GetByIdRatingResponse>(rating);
            return response;
        }
    }
}