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

namespace Application.Features.Ratings.Commands.Update;

public class UpdateRatingCommand : IRequest<UpdatedRatingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required int CustomerId { get; set; }
    public required int ProductId { get; set; }
    public required int Score { get; set; }

    public string[] Roles => [Admin, Write, RatingsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRatings"];

    public class UpdateRatingCommandHandler : IRequestHandler<UpdateRatingCommand, UpdatedRatingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;
        private readonly RatingBusinessRules _ratingBusinessRules;

        public UpdateRatingCommandHandler(IMapper mapper, IRatingRepository ratingRepository,
                                         RatingBusinessRules ratingBusinessRules)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _ratingBusinessRules = ratingBusinessRules;
        }

        public async Task<UpdatedRatingResponse> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
            Rating? rating = await _ratingRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _ratingBusinessRules.RatingShouldExistWhenSelected(rating);
            rating = _mapper.Map(request, rating);

            await _ratingRepository.UpdateAsync(rating!);

            UpdatedRatingResponse response = _mapper.Map<UpdatedRatingResponse>(rating);
            return response;
        }
    }
}