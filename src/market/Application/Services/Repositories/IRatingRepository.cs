using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRatingRepository : IAsyncRepository<Rating, int>, IRepository<Rating, int>
{
}