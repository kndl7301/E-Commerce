using Application.Features.Ratings.Constants;
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

namespace Application.Features.Ratings.Commands.Delete;

public class DeleteRatingCommand : IRequest<DeletedRatingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, RatingsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRatings"];

    public class DeleteRatingCommandHandler : IRequestHandler<DeleteRatingCommand, DeletedRatingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;
        private readonly RatingBusinessRules _ratingBusinessRules;

        public DeleteRatingCommandHandler(IMapper mapper, IRatingRepository ratingRepository,
                                         RatingBusinessRules ratingBusinessRules)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _ratingBusinessRules = ratingBusinessRules;
        }

        public async Task<DeletedRatingResponse> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            Rating? rating = await _ratingRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _ratingBusinessRules.RatingShouldExistWhenSelected(rating);

            await _ratingRepository.DeleteAsync(rating!);

            DeletedRatingResponse response = _mapper.Map<DeletedRatingResponse>(rating);
            return response;
        }
    }
}