using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PaymentRepository : EfRepositoryBase<Payment, int, BaseDbContext>, IPaymentRepository
{
    public PaymentRepository(BaseDbContext context) : base(context)
    {
    }
}