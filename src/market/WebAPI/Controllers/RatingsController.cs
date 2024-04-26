using Application.Features.Ratings.Commands.Create;
using Application.Features.Ratings.Commands.Delete;
using Application.Features.Ratings.Commands.Update;
using Application.Features.Ratings.Queries.GetById;
using Application.Features.Ratings.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RatingsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedRatingResponse>> Add([FromBody] CreateRatingCommand command)
    {
        CreatedRatingResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedRatingResponse>> Update([FromBody] UpdateRatingCommand command)
    {
        UpdatedRatingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedRatingResponse>> Delete([FromRoute] int id)
    {
        DeleteRatingCommand command = new() { Id = id };

        DeletedRatingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdRatingResponse>> GetById([FromRoute] int id)
    {
        GetByIdRatingQuery query = new() { Id = id };

        GetByIdRatingResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListRatingQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRatingQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListRatingListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}