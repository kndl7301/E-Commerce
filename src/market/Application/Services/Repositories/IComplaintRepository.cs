using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IComplaintRepository : IAsyncRepository<Complaint, int>, IRepository<Complaint, int>
{
}