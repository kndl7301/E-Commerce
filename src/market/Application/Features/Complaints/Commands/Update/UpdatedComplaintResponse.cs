using NArchitecture.Core.Application.Responses;

namespace Application.Features.Complaints.Commands.Update;

public class UpdatedComplaintResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ComplaintText { get; set; }
    public DateTime ComplaintDate { get; set; }
    public int CustomerId { get; set; }
    public string CustomerEmail { get; set; }
}