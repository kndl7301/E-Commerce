using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPaymentRepository : IAsyncRepository<Payment, int>, IRepository<Payment, int>
{
}