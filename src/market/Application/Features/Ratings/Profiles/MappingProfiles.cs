using Application.Features.Ratings.Commands.Create;
using Application.Features.Ratings.Commands.Delete;
using Application.Features.Ratings.Commands.Update;
using Application.Features.Ratings.Queries.GetById;
using Application.Features.Ratings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Ratings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateRatingCommand, Rating>();
        CreateMap<Rating, CreatedRatingResponse>();

        CreateMap<UpdateRatingCommand, Rating>();
        CreateMap<Rating, UpdatedRatingResponse>();

        CreateMap<DeleteRatingCommand, Rating>();
        CreateMap<Rating, DeletedRatingResponse>();

        CreateMap<Rating, GetByIdRatingResponse>();

        CreateMap<Rating, GetListRatingListItemDto>();
        CreateMap<IPaginate<Rating>, GetListResponse<GetListRatingListItemDto>>();
    }
}