using Application.Features.Complaints.Constants;
using Application.Features.Complaints.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Complaints.Constants.ComplaintsOperationClaims;

namespace Application.Features.Complaints.Commands.Update;

public class UpdateComplaintCommand : IRequest<UpdatedComplaintResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string ComplaintText { get; set; }
    public required DateTime ComplaintDate { get; set; }
    public required int CustomerId { get; set; }
    public required string CustomerEmail { get; set; }

    public string[] Roles => [Admin, Write, ComplaintsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetComplaints"];

    public class UpdateComplaintCommandHandler : IRequestHandler<UpdateComplaintCommand, UpdatedComplaintResponse>
    {
        private readonly IMapper _mapper;
        private readonly IComplaintRepository _complaintRepository;
        private readonly ComplaintBusinessRules _complaintBusinessRules;

        public UpdateComplaintCommandHandler(IMapper mapper, IComplaintRepository complaintRepository,
                                         ComplaintBusinessRules complaintBusinessRules)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
            _complaintBusinessRules = complaintBusinessRules;
        }

        public async Task<UpdatedComplaintResponse> Handle(UpdateComplaintCommand request, CancellationToken cancellationToken)
        {
            Complaint? complaint = await _complaintRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _complaintBusinessRules.ComplaintShouldExistWhenSelected(complaint);
            complaint = _mapper.Map(request, complaint);

            await _complaintRepository.UpdateAsync(complaint!);

            UpdatedComplaintResponse response = _mapper.Map<UpdatedComplaintResponse>(complaint);
            return response;
        }
    }
}