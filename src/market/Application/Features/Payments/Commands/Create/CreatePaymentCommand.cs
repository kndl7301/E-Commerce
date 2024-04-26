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

namespace Application.Features.Payments.Commands.Create;

public class CreatePaymentCommand : IRequest<CreatedPaymentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required int CardNumber { get; set; }
    public required string PaymentType { get; set; }
    public required DateTime PaymentDate { get; set; }
    public required int OrderId { get; set; }

    public string[] Roles => [Admin, Write, PaymentsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPayments"];

    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatedPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;
        private readonly PaymentBusinessRules _paymentBusinessRules;

        public CreatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository,
                                         PaymentBusinessRules paymentBusinessRules)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _paymentBusinessRules = paymentBusinessRules;
        }

        public async Task<CreatedPaymentResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            Payment payment = _mapper.Map<Payment>(request);

            await _paymentRepository.AddAsync(payment);

            CreatedPaymentResponse response = _mapper.Map<CreatedPaymentResponse>(payment);
            return response;
        }
    }
}