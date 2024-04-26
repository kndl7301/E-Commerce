using Application.Features.Ratings.Constants;
using Application.Features.Ratings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Ratings.Constants.RatingsOperationClaims;

namespace Application.Features.Ratings.Commands.Create;

public class CreateRatingCommand : IRequest<CreatedRatingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required int CustomerId { get; set; }
    public required int ProductId { get; set; }
    public required int Score { get; set; }

    public string[] Roles => [Admin, Write, RatingsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRatings"];

    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, CreatedRatingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;
        private readonly RatingBusinessRules _ratingBusinessRules;

        public CreateRatingCommandHandler(IMapper mapper, IRatingRepository ratingRepository,
                                         RatingBusinessRules ratingBusinessRules)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _ratingBusinessRules = ratingBusinessRules;
        }

        public async Task<CreatedRatingResponse> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            Rating rating = _mapper.Map<Rating>(request);

            await _ratingRepository.AddAsync(rating);

            CreatedRatingResponse response = _mapper.Map<CreatedRatingResponse>(rating);
            return response;
        }
    }
}