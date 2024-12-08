using Application.Features.CarStatus.Commands.Create;
using Application.Features.CarStatus.Commands.Delete;
using Application.Features.CarStatus.Commands.Update;
using Application.Features.CarStatus.Queries.GetById;
using Application.Features.CarStatus.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CarStatus.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CarStatusEntity, CreateCarStatusCommand>().ReverseMap();
        CreateMap<CarStatusEntity, CreatedCarStatusResponse>().ReverseMap();
        CreateMap<CarStatusEntity, UpdateCarStatusCommand>().ReverseMap();
        CreateMap<CarStatusEntity, UpdatedCarStatusResponse>().ReverseMap();
        CreateMap<CarStatusEntity, DeleteCarStatusCommand>().ReverseMap();
        CreateMap<CarStatusEntity, DeletedCarStatusResponse>().ReverseMap();
        CreateMap<CarStatusEntity, GetByIdCarStatusResponse>().ReverseMap();
        CreateMap<CarStatusEntity, GetListCarStatusListItemDto>().ReverseMap();
        CreateMap<IPaginate<CarStatusEntity>, GetListResponse<GetListCarStatusListItemDto>>().ReverseMap();
    }
}