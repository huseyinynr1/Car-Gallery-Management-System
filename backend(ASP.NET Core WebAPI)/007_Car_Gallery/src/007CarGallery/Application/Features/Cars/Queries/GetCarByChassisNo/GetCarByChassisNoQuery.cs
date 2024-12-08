using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetCarByChassisNo;
public class GetCarByChassisNoQuery : IRequest<GetCarByChassisNoResponse>
{
    public string? BrandName { get; set; }
    public string? ModelName { get; set; }
    public string? ChassisNo { get; set; }
}

public class GetCarByChassisNoCommandHandler : IRequestHandler<GetCarByChassisNoQuery, GetCarByChassisNoResponse>
{
    private readonly IMapper _mapper;
    private readonly ICarRepository _carRepository;
    private readonly CarBusinessRules _carBusinessRules;

    public GetCarByChassisNoCommandHandler(IMapper mapper, ICarRepository carRepository, CarBusinessRules carBusinessRules)
    {
        _mapper = mapper;
        _carRepository = carRepository;
        _carBusinessRules = carBusinessRules;
    }

    public async Task<GetCarByChassisNoResponse> Handle(GetCarByChassisNoQuery request, CancellationToken cancellationToken)
    {
        // Kullanıcıdan gelen verileri kontrol eden iş kuralları.
        //await _carBusinessRules.BrandShouldBeSelected(request.BrandName);
        //await _carBusinessRules.ModelShouldBeSelected(request.ModelName);
        //await _carBusinessRules.ChassisNoShouldBeProvided(request.ChassisNo);

        Car? car = await _carRepository.GetAsync(predicate: c => c.ChassisNo == request.ChassisNo
        && c.Brand.Name == request.BrandName
        && c.Model.Name == request.ModelName,
        include: c => c.Include(c => c.Brand).Include(c => c.Model));

        await _carBusinessRules.CarShouldExistWhenSelected(car);

        GetCarByChassisNoResponse response = _mapper.Map<GetCarByChassisNoResponse>(car);
        return response;

    }
}