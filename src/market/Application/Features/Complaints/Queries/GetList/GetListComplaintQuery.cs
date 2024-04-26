using Application.Features.Complaints.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Complaints.Constants.ComplaintsOperationClaims;

namespace Application.Features.Complaints.Queries.GetList;

public class GetListComplaintQuery : IRequest<GetListResponse<GetListComplaintListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListComplaints({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetComplaints";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListComplaintQueryHandler : IRequestHandler<GetListComplaintQuery, GetListResponse<GetListComplaintListItemDto>>
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IMapper _mapper;

        public GetListComplaintQueryHandler(IComplaintRepository complaintRepository, IMapper mapper)
        {
            _complaintRepository = complaintRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListComplaintListItemDto>> Handle(GetListComplaintQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Complaint> complaints = await _complaintRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListComplaintListItemDto> response = _mapper.Map<GetListResponse<GetListComplaintListItemDto>>(complaints);
            return response;
        }
    }
}