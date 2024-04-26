using NArchitecture.Core.Application.Responses;

namespace Application.Features.Payments.Commands.Delete;

public class DeletedPaymentResponse : IResponse
{
    public int Id { get; set; }
}