using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetFilteredCar;
public class GetFilteredCarListQuery : IRequest<GetListResponse<GetListFilteredCarListItemDto>>
{
    public int? BrandId { get; set; }
    public int? ModelId { get; set; }
    public int? Year { get; set; }
    public double? MinPrice { get; set; }
    public double? MaxPrice { get; set; }
    public int? TransmissionId { get; set; }
    public int? FuelId { get; set; }
    public int? StatusId { get; set; }
    public int? MinKilometer { get; set; }
    public int? MaxKilometer { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public int PageIndex { get; set; } = 0;  // Varsayılan olarak ilk sayfa
    public int PageSize { get; set; } = 10;  // Varsayılan olarak her sayfada 10 kayıt
}


public class GetFilteredCarListQueryHandler : IRequestHandler<GetFilteredCarListQuery, GetListResponse<GetListFilteredCarListItemDto>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetFilteredCarListQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListFilteredCarListItemDto>> Handle(GetFilteredCarListQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Car> carList = await _carRepository.GetListAsync(
            predicate: c =>
                (request.BrandId == null || c.BrandId == request.BrandId) &&
                (request.ModelId == null || c.ModelId == request.ModelId) &&
                (!request.MinPrice.HasValue || c.Price >= request.MinPrice) &&
                (!request.MaxPrice.HasValue || c.Price <= request.MaxPrice) &&
                (request.TransmissionId == null || c.TransmissionId == request.TransmissionId) &&
                (request.FuelId == null || c.FuelId == request.FuelId) &&
                (request.StatusId == null || c.CarStatus.Id == request.StatusId) &&
                (!request.MinKilometer.HasValue || c.Kilometer >= request.MinKilometer) &&
                (!request.MaxKilometer.HasValue || c.Kilometer <= request.MaxKilometer),
            include: c => c.Include(c => c.Brand).Include(c => c.Model).Include(c => c.Transmission).Include(c => c.Fuel).Include(c => c.CarStatus),
            index: request.PageIndex,
            size: request.PageSize
        );

        GetListResponse<GetListFilteredCarListItemDto> response = _mapper.Map<GetListResponse<GetListFilteredCarListItemDto>>(carList);
        return response;
    }

}