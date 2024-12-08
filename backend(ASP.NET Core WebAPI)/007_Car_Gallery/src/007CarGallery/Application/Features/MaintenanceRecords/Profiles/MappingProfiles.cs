using Application.Features.MaintenanceRecords.Commands.Create;
using Application.Features.MaintenanceRecords.Commands.Delete;
using Application.Features.MaintenanceRecords.Commands.Update;
using Application.Features.MaintenanceRecords.Queries.GetById;
using Application.Features.MaintenanceRecords.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.MaintenanceRecords.Queries.GetPastMaintenanceRecordList;
using Application.Features.MaintenanceRecords.Queries.GetActiveMaintenanceRecordList;
using Application.Features.MaintenanceRecords.Queries.GetRecordByFilter;

namespace Application.Features.MaintenanceRecords.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateMaintenanceRecordCommand, MaintenanceRecord >().ReverseMap();
        CreateMap<MaintenanceRecord, CreatedMaintenanceRecordResponse>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : null))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type != null ? src.Type.Type : null))
            .ForMember(dest => dest.MaintenanceState, opt => opt.MapFrom(src => src.MaintenanceState != null ? src.MaintenanceState.State : null))
            .ForMember(dest => dest.MaintenanceType, opt => opt.MapFrom(src => src.MaintenanceType != null ? src.MaintenanceType.Type : null))
            .ReverseMap();



        CreateMap<UpdateMaintenanceRecordCommand, MaintenanceRecord>().ReverseMap();
        CreateMap<MaintenanceRecord, UpdatedMaintenanceRecordResponse>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : null))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type != null ? src.Type.Type : null))
            .ForMember(dest => dest.MaintenanceState, opt => opt.MapFrom(src => src.MaintenanceState != null ? src.MaintenanceState.State : null))
            .ForMember(dest => dest.MaintenanceType, opt => opt.MapFrom(src => src.MaintenanceType != null ? src.MaintenanceType.Type : null))
            .ReverseMap();

        CreateMap<MaintenanceRecord, DeleteMaintenanceRecordCommand>().ReverseMap();
        CreateMap<MaintenanceRecord, DeletedMaintenanceRecordResponse>().ReverseMap();

        CreateMap<MaintenanceRecord, GetByIdMaintenanceRecordResponse>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : null))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type != null ? src.Type.Type : null))
            .ForMember(dest => dest.MaintenanceState, opt => opt.MapFrom(src => src.MaintenanceState != null ? src.MaintenanceState.State : null))
            .ForMember(dest => dest.MaintenanceType, opt => opt.MapFrom(src => src.MaintenanceType != null ? src.MaintenanceType.Type : null))
            .ReverseMap();

        CreateMap<MaintenanceRecord, GetListMaintenanceRecordListItemDto>().ReverseMap();
        CreateMap<IPaginate<MaintenanceRecord>, GetListResponse<GetListMaintenanceRecordListItemDto>>().ReverseMap();

        CreateMap<MaintenanceRecord, GetListPastMaintenanceRecordListItemDto>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : null))
             .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type != null ? src.Type.Type : null))
            .ForMember(dest => dest.MaintenanceState, opt => opt.MapFrom(src => src.MaintenanceState != null ? src.MaintenanceState.State : null))
            .ForMember(dest => dest.MaintenanceType, opt => opt.MapFrom(src => src.MaintenanceType != null ? src.MaintenanceType.Type : null))
            .ReverseMap();
        CreateMap<IPaginate<MaintenanceRecord>, GetListResponse<GetListPastMaintenanceRecordListItemDto>>().ReverseMap();

        CreateMap<MaintenanceRecord, GetListActiveMaintenanceRecordListItemDto>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : null))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type != null ? src.Type.Type : null))
            .ForMember(dest => dest.MaintenanceState, opt => opt.MapFrom(src => src.MaintenanceState != null ? src.MaintenanceState.State : null))
            .ForMember(dest => dest.MaintenanceType, opt => opt.MapFrom(src => src.MaintenanceType != null ? src.MaintenanceType.Type : null))
            .ReverseMap();
        CreateMap<IPaginate<MaintenanceRecord>, GetListResponse<GetListActiveMaintenanceRecordListItemDto>>().ReverseMap();


        CreateMap<MaintenanceRecord, GetRecordByFilterItemDto>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : null))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.MaintenanceState != null ? src.MaintenanceState.State : null))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.MaintenanceType != null ? src.MaintenanceType.Type : null))
            .ReverseMap();  
        CreateMap<IPaginate<MaintenanceRecord>, GetListResponse<GetRecordByFilterItemDto>>().ReverseMap(); 
    }
}