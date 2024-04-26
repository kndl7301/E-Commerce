using NArchitecture.Core.Application.Responses;

namespace Application.Features.Addresses.Commands.Create;

public class CreatedAddressResponse : IResponse
{
    public int Id { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public string Title { get; set; }
    public int CustomerId { get; set; }
}