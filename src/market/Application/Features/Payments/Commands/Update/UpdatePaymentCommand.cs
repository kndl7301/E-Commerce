using Application.Features.Payments.Constants;
using Application.Features.Payments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Payments.Constants.PaymentsOperationClaims;

namespace Application.Features.Payments.Commands.Update;

public class UpdatePaymentCommand : IRequest<UpdatedPaymentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required int CardNumber { get; set; }
    public required string PaymentType { get; set; }
    public required DateTime PaymentDate { get; set; }
    public required int OrderId { get; set; }

    public string[] Roles => [Admin, Write, PaymentsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPayments"];

    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, UpdatedPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;
        private readonly PaymentBusinessRules _paymentBusinessRules;

        public UpdatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository,
                                         PaymentBusinessRules paymentBusinessRules)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _paymentBusinessRules = paymentBusinessRules;
        }

        public async Task<UpdatedPaymentResponse> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            Payment? payment = await _paymentRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _paymentBusinessRules.PaymentShouldExistWhenSelected(payment);
            payment = _mapper.Map(request, payment);

            await _paymentRepository.UpdateAsync(payment!);

            UpdatedPaymentResponse response = _mapper.Map<UpdatedPaymentResponse>(payment);
            return response;
        }
    }
}