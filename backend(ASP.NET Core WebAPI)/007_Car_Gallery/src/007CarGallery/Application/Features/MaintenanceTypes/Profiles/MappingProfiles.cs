using Application.Features.MaintenanceTypes.Commands.Create;
using Application.Features.MaintenanceTypes.Commands.Delete;
using Application.Features.MaintenanceTypes.Commands.Update;
using Application.Features.MaintenanceTypes.Queries.GetById;
using Application.Features.MaintenanceTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MaintenanceTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<MaintenanceType, CreateMaintenanceTypeCommand>().ReverseMap();
        CreateMap<MaintenanceType, CreatedMaintenanceTypeResponse>().ReverseMap();
        CreateMap<MaintenanceType, UpdateMaintenanceTypeCommand>().ReverseMap();
        CreateMap<MaintenanceType, UpdatedMaintenanceTypeResponse>().ReverseMap();
        CreateMap<MaintenanceType, DeleteMaintenanceTypeCommand>().ReverseMap();
        CreateMap<MaintenanceType, DeletedMaintenanceTypeResponse>().ReverseMap();
        CreateMap<MaintenanceType, GetByIdMaintenanceTypeResponse>().ReverseMap();
        CreateMap<MaintenanceType, GetListMaintenanceTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaintenanceType>, GetListResponse<GetListMaintenanceTypeListItemDto>>().ReverseMap();
    }
}