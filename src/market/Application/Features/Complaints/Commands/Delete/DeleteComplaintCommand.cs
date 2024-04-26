using Application.Features.Complaints.Constants;
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

namespace Application.Features.Complaints.Commands.Delete;

public class DeleteComplaintCommand : IRequest<DeletedComplaintResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ComplaintsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetComplaints"];

    public class DeleteComplaintCommandHandler : IRequestHandler<DeleteComplaintCommand, DeletedComplaintResponse>
    {
        private readonly IMapper _mapper;
        private readonly IComplaintRepository _complaintRepository;
        private readonly ComplaintBusinessRules _complaintBusinessRules;

        public DeleteComplaintCommandHandler(IMapper mapper, IComplaintRepository complaintRepository,
                                         ComplaintBusinessRules complaintBusinessRules)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
            _complaintBusinessRules = complaintBusinessRules;
        }

        public async Task<DeletedComplaintResponse> Handle(DeleteComplaintCommand request, CancellationToken cancellationToken)
        {
            Complaint? complaint = await _complaintRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _complaintBusinessRules.ComplaintShouldExistWhenSelected(complaint);

            await _complaintRepository.DeleteAsync(complaint!);

            DeletedComplaintResponse response = _mapper.Map<DeletedComplaintResponse>(complaint);
            return response;
        }
    }
}