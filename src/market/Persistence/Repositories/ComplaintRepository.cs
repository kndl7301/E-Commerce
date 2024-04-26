using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ComplaintRepository : EfRepositoryBase<Complaint, int, BaseDbContext>, IComplaintRepository
{
    public ComplaintRepository(BaseDbContext context) : base(context)
    {
    }
}