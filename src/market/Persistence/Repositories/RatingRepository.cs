using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RatingRepository : EfRepositoryBase<Rating, int, BaseDbContext>, IRatingRepository
{
    public RatingRepository(BaseDbContext context) : base(context)
    {
    }
}