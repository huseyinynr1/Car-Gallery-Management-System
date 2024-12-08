using Application.Features.MaintenanceStates.Commands.Create;
using Application.Features.MaintenanceStates.Commands.Delete;
using Application.Features.MaintenanceStates.Commands.Update;
using Application.Features.MaintenanceStates.Queries.GetById;
using Application.Features.MaintenanceStates.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaintenanceStates.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaintenanceState, CreateMaintenanceStateCommand>().ReverseMap();
        CreateMap<MaintenanceState, CreatedMaintenanceStateResponse>().ReverseMap();
        CreateMap<MaintenanceState, UpdateMaintenanceStateCommand>().ReverseMap();
        CreateMap<MaintenanceState, UpdatedMaintenanceStateResponse>().ReverseMap();
        CreateMap<MaintenanceState, DeleteMaintenanceStateCommand>().ReverseMap();
        CreateMap<MaintenanceState, DeletedMaintenanceStateResponse>().ReverseMap();
        CreateMap<MaintenanceState, GetByIdMaintenanceStateResponse>().ReverseMap();
        CreateMap<MaintenanceState, GetListMaintenanceStateListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaintenanceState>, GetListResponse<GetListMaintenanceStateListItemDto>>().ReverseMap();
    }
}