using Application.Features.Comments.Constants;
using Application.Features.Comments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Comments.Constants.CommentsOperationClaims;

namespace Application.Features.Comments.Commands.Create;

public class CreateCommentCommand : IRequest<CreatedCommentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Title { get; set; }
    public required string CommentText { get; set; }
    public required DateTime CommentDate { get; set; }
    public required int CustomerId { get; set; }
    public required int ProductId { get; set; }

    public string[] Roles => [Admin, Write, CommentsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetComments"];

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreatedCommentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly CommentBusinessRules _commentBusinessRules;

        public CreateCommentCommandHandler(IMapper mapper, ICommentRepository commentRepository,
                                         CommentBusinessRules commentBusinessRules)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            _commentBusinessRules = commentBusinessRules;
        }

        public async Task<CreatedCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment comment = _mapper.Map<Comment>(request);

            await _commentRepository.AddAsync(comment);

            CreatedCommentResponse response = _mapper.Map<CreatedCommentResponse>(comment);
            return response;
        }
    }
}