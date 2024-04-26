using Application.Features.Payments.Commands.Create;
using Application.Features.Payments.Commands.Delete;
using Application.Features.Payments.Commands.Update;
using Application.Features.Payments.Queries.GetById;
using Application.Features.Payments.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPaymentResponse>> Add([FromBody] CreatePaymentCommand command)
    {
        CreatedPaymentResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPaymentResponse>> Update([FromBody] UpdatePaymentCommand command)
    {
        UpdatedPaymentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPaymentResponse>> Delete([FromRoute] int id)
    {
        DeletePaymentCommand command = new() { Id = id };

        DeletedPaymentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPaymentResponse>> GetById([FromRoute] int id)
    {
        GetByIdPaymentQuery query = new() { Id = id };

        GetByIdPaymentResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPaymentQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPaymentQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPaymentListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}