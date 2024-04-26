using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Complaints.Queries.GetList;

public class GetListComplaintListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ComplaintText { get; set; }
    public DateTime ComplaintDate { get; set; }
    public int CustomerId { get; set; }
    public string CustomerEmail { get; set; }
}