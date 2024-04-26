using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Orders.Queries.GetList;

public class GetListOrderListItemDto : IDto
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