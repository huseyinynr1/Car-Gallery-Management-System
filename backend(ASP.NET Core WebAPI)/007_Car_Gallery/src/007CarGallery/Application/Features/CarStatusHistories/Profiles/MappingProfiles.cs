using Application.Features.CarStatusHistories.Commands.Create;
using Application.Features.CarStatusHistories.Commands.Delete;
using Application.Features.CarStatusHistories.Commands.Update;
using Application.Features.CarStatusHistories.Queries.GetById;
using Application.Features.CarStatusHistories.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CarStatusHistories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CarStatusHistory, CreateCarStatusHistoryCommand>().ReverseMap();
        CreateMap<CarStatusHistory, CreatedCarStatusHistoryResponse>().ReverseMap();
        CreateMap<CarStatusHistory, UpdateCarStatusHistoryCommand>().ReverseMap();
        CreateMap<CarStatusHistory, UpdatedCarStatusHistoryResponse>().ReverseMap();
        CreateMap<CarStatusHistory, DeleteCarStatusHistoryCommand>().ReverseMap();
        CreateMap<CarStatusHistory, DeletedCarStatusHistoryResponse>().ReverseMap();
        CreateMap<CarStatusHistory, GetByIdCarStatusHistoryResponse>().ReverseMap();
        CreateMap<CarStatusHistory, GetListCarStatusHistoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<CarStatusHistory>, GetListResponse<GetListCarStatusHistoryListItemDto>>().ReverseMap();
    }
}