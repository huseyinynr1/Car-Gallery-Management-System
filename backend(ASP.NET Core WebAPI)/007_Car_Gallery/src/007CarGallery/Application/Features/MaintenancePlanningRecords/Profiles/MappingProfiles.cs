using Application.Features.MaintenancePlanningRecords.Commands.Create;
using Application.Features.MaintenancePlanningRecords.Commands.Delete;
using Application.Features.MaintenancePlanningRecords.Commands.Update;
using Application.Features.MaintenancePlanningRecords.Queries.GetById;
using Application.Features.MaintenancePlanningRecords.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.MaintenancePlanningRecords.Queries.GetPendingMaintenanceRecordList;

namespace Application.Features.MaintenancePlanningRecords.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateMaintenancePlanningRecordCommand ,MaintenancePlanningRecord>().ReverseMap();

        CreateMap<MaintenancePlanningRecord, CreatedMaintenancePlanningRecordResponse>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : null))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type != null ? src.Type.Type : null))
            .ForMember(dest => dest.MaintenanceState, opt => opt.MapFrom(src => src.MaintenanceState != null ? src.MaintenanceState.State : null))
            .ForMember(dest => dest.MaintenanceType, opt => opt.MapFrom(src => src.MaintenanceType != null ? src.MaintenanceType.Type : null))
            .ReverseMap();

        CreateMap<UpdateMaintenancePlanningRecordCommand, MaintenancePlanningRecord >().ReverseMap();
        CreateMap<MaintenancePlanningRecord, UpdatedMaintenancePlanningRecordResponse>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : null))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type != null ? src.Type.Type : null))
            .ForMember(dest => dest.MaintenanceState, opt => opt.MapFrom(src => src.MaintenanceState != null ? src.MaintenanceState.State : null))
            .ForMember(dest => dest.MaintenanceType, opt => opt.MapFrom(src => src.MaintenanceType != null ? src.MaintenanceType.Type : null))
            .ReverseMap();

        CreateMap<DeleteMaintenancePlanningRecordCommand, MaintenancePlanningRecord>().ReverseMap();
        CreateMap<MaintenancePlanningRecord, DeletedMaintenancePlanningRecordResponse>().ReverseMap();

        CreateMap<MaintenancePlanningRecord, GetByIdMaintenancePlanningRecordResponse>().ReverseMap();
        CreateMap<MaintenancePlanningRecord, GetListMaintenancePlanningRecordListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaintenancePlanningRecord>, GetListResponse<GetListMaintenancePlanningRecordListItemDto>>().ReverseMap();

        CreateMap<MaintenancePlanningRecord, GetListPendingMaintenanceRecordListItemDto>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : null))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type != null ? src.Type.Type : null))
            .ForMember(dest => dest.MaintenanceState, opt => opt.MapFrom(src => src.MaintenanceState != null ? src.MaintenanceState.State : null))
            .ForMember(dest => dest.MaintenanceType, opt => opt.MapFrom(src => src.MaintenanceType != null ? src.MaintenanceType.Type : null))

            .ReverseMap();
        CreateMap<IPaginate<MaintenancePlanningRecord>, GetListResponse<GetListPendingMaintenanceRecordListItemDto>>().ReverseMap();
    }
}