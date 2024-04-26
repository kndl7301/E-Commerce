using NArchitecture.Core.Application.Responses;

namespace Application.Features.Complaints.Commands.Delete;

public class DeletedComplaintResponse : IResponse
{
    public int Id { get; set; }
}