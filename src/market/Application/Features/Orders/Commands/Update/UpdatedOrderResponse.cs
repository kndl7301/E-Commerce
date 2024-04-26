using NArchitecture.Core.Application.Responses;

namespace Application.Features.Orders.Commands.Update;

public class UpdatedOrderResponse : IResponse
{
    public Guid Id { get; set; }
    public int OrderNumber { get; set; }
    public int Totalprice { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int PaymentId { get; set; }
    public DateTime OrderDate { get; set; }
    public bool Status { get; set; }
}