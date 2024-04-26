using Application.Features.Ratings.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Ratings.Rules;

public class RatingBusinessRules : BaseBusinessRules
{
    private readonly IRatingRepository _ratingRepository;
    private readonly ILocalizationService _localizationService;

    public RatingBusinessRules(IRatingRepository ratingRepository, ILocalizationService localizationService)
    {
        _ratingRepository = ratingRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RatingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RatingShouldExistWhenSelected(Rating? rating)
    {
        if (rating == null)
            await throwBusinessException(RatingsBusinessMessages.RatingNotExists);
    }

    public async Task RatingIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Rating? rating = await _ratingRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RatingShouldExistWhenSelected(rating);
    }
}