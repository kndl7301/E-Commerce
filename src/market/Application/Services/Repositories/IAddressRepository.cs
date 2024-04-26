using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAddressRepository : IAsyncRepository<Address, int>, IRepository<Address, int>
{
}