using Application.Features.VehicleTypes.Commands.Create;
using Application.Features.VehicleTypes.Commands.Delete;
using Application.Features.VehicleTypes.Commands.Update;
using Application.Features.VehicleTypes.Queries.GetById;
using Application.Features.VehicleTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.VehicleTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<VehicleType, CreateVehicleTypeCommand>().ReverseMap();
        CreateMap<VehicleType, CreatedVehicleTypeResponse>().ReverseMap();
        CreateMap<VehicleType, UpdateVehicleTypeCommand>().ReverseMap();
        CreateMap<VehicleType, UpdatedVehicleTypeResponse>().ReverseMap();
        CreateMap<VehicleType, DeleteVehicleTypeCommand>().ReverseMap();
        CreateMap<VehicleType, DeletedVehicleTypeResponse>().ReverseMap();
        CreateMap<VehicleType, GetByIdVehicleTypeResponse>().ReverseMap();
        CreateMap<VehicleType, GetListVehicleTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<VehicleType>, GetListResponse<GetListVehicleTypeListItemDto>>().ReverseMap();
    }
}