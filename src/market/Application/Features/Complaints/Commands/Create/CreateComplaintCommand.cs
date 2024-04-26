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

namespace Application.Features.Complaints.Commands.Create;

public class CreateComplaintCommand : IRequest<CreatedComplaintResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Title { get; set; }
    public required string ComplaintText { get; set; }
    public required DateTime ComplaintDate { get; set; }
    public required int CustomerId { get; set; }
    public required string CustomerEmail { get; set; }

    public string[] Roles => [Admin, Write, ComplaintsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetComplaints"];

    public class CreateComplaintCommandHandler : IRequestHandler<CreateComplaintCommand, CreatedComplaintResponse>
    {
        private readonly IMapper _mapper;
        private readonly IComplaintRepository _complaintRepository;
        private readonly ComplaintBusinessRules _complaintBusinessRules;

        public CreateComplaintCommandHandler(IMapper mapper, IComplaintRepository complaintRepository,
                                         ComplaintBusinessRules complaintBusinessRules)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
            _complaintBusinessRules = complaintBusinessRules;
        }

        public async Task<CreatedComplaintResponse> Handle(CreateComplaintCommand request, CancellationToken cancellationToken)
        {
            Complaint complaint = _mapper.Map<Complaint>(request);

            await _complaintRepository.AddAsync(complaint);

            CreatedComplaintResponse response = _mapper.Map<CreatedComplaintResponse>(complaint);
            return response;
        }
    }
}