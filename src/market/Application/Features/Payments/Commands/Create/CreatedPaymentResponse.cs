using NArchitecture.Core.Application.Responses;

namespace Application.Features.Payments.Commands.Create;

public class CreatedPaymentResponse : IResponse
{
    public int Id { get; set; }
    public int CardNumber { get; set; }
    public string PaymentType { get; set; }
    public DateTime PaymentDate { get; set; }
    public int OrderId { get; set; }
}