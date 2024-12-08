using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Cars.Queries.GetCarByChassisNo;
using Application.Features.Cars.Queries.GetFilteredCar;

namespace Application.Features.Cars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // CreateCarCommand'den Car entity'sine mapleme
        CreateMap<CreateCarCommand, Car>().ReverseMap();

        // UpdateCarCommand'den Car entity'sine mapleme
        CreateMap<UpdateCarCommand, Car>().ReverseMap();

        CreateMap<Car, CreatedCarResponse>()
     .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
     .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : null))
     .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => src.Fuel != null ? src.Fuel.Type : null))
     .ForMember(dest => dest.TransmissionType, opt => opt.MapFrom(src => src.Transmission != null ? src.Transmission.Type : null))
     .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.CarStatus != null ? src.CarStatus.Status : null))
     .ReverseMap();

        CreateMap<Car, UpdatedCarResponse>()
      .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : null))
     .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : null))
     .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => src.Fuel != null ? src.Fuel.Type : null))
     .ForMember(dest => dest.TransmissionType, opt => opt.MapFrom(src => src.Transmission != null ? src.Transmission.Type : null))
     .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.CarStatus != null ? src.CarStatus.Status : null))
            .ReverseMap();
        CreateMap<Car, DeleteCarCommand>().ReverseMap();
        CreateMap<Car, DeletedCarResponse>().ReverseMap();
        CreateMap<Car, GetByIdCarResponse>().ReverseMap();

        // Car entity'sini GetListCarListItemDto'ya mapleme
        CreateMap<Car, GetListCarListItemDto>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model.Name))
            .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => src.Fuel.Type))
            .ForMember(dest => dest.TransmissionType, opt => opt.MapFrom(src => src.Transmission.Type))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.CarStatus.Status))
            .ReverseMap();

        CreateMap<IPaginate<Car>, GetListResponse<GetListCarListItemDto>>().ReverseMap();

        CreateMap<Car, GetListFilteredCarListItemDto>()
    .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))  // BrandId'den BrandName'i alýyoruz
    .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model.Name))
    .ForMember(dest => dest.TransmissionType, opt => opt.MapFrom(src => src.Transmission.Type))
    .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => src.Fuel.Type))
    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.CarStatus.Status))
    .ReverseMap();


        CreateMap<IPaginate<Car>, GetListResponse<GetListFilteredCarListItemDto>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)) // Sayfalama içerisindeki araba listesini mapliyoruz
            .ReverseMap();

        CreateMap<Car, GetCarByChassisNoQuery>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model.Name))
            .ReverseMap();
        CreateMap<Car, GetCarByChassisNoResponse>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model.Name))
            .ReverseMap();

    }
}