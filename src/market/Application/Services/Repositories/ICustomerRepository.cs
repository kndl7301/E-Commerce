using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomerRepository : IAsyncRepository<Customer, int>, IRepository<Customer, int>
{
}