using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Payments.Queries.GetList;

public class GetListPaymentListItemDto : IDto
{
    public int Id { get; set; }
    public int CardNumber { get; set; }
    public string PaymentType { get; set; }
    public DateTime PaymentDate { get; set; }
    public int OrderId { get; set; }
}