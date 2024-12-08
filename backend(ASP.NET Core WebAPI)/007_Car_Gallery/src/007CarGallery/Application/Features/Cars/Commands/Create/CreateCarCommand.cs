using Application.Features.Cars.Constants;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Cars.Constants.CarsOperationClaims;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommand : IRequest<CreatedCarResponse>, ISecuredRequest
{
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string TransmissionType { get; set; }
    public string FuelType { get; set; }
    public string? Status { get; set; }
    //public int? ImageId { get; set; }
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
    public int Kilometer { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }

    public string[] Roles => [Admin, Write, CarsOperationClaims.Create];

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreatedCarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IModelRepository _modelRepository;
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IFuelRepository _fuelRepository;
        private readonly ICarStatusRepository _carStatusRepository;
        private readonly CarBusinessRules _carBusinessRules;

        public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository, IBrandRepository brandRepository,
            IModelRepository modelRepository, ITransmissionRepository transmissionRepository, IFuelRepository fuelRepository, 
            ICarStatusRepository carStatusRepository, CarBusinessRules carBusinessRules)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _brandRepository = brandRepository;
            _modelRepository = modelRepository;
            _transmissionRepository = transmissionRepository;
            _fuelRepository = fuelRepository;
            _carStatusRepository = carStatusRepository;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<CreatedCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetAsync(predicate: b => b.Name == request.BrandName);
            await _carBusinessRules.BrandShouldExistWhenSelected(brand);

            var model = await _modelRepository.GetAsync(predicate: m => m.Name == request.ModelName);
            await _carBusinessRules.ModelShouldExistWhenSelected(model);

            var transmission = await _transmissionRepository.GetAsync(predicate: t => t.Type == request.TransmissionType);
            await _carBusinessRules.TransmissionShouldExistWhenSelected(transmission);

            var fuel = await _fuelRepository.GetAsync(predicate: f => f.Type == request.FuelType);
            await _carBusinessRules.FuelShouldExistWhenSelected(fuel);

            var status = await _carStatusRepository.GetAsync(predicate: cs => cs.Status == request.Status);
            await _carBusinessRules.StatusShouldExistWhenSelected(status);

            Car car = _mapper.Map<Car>(request);

            car.BrandId = brand.Id;
            car.ModelId = model.Id;
            car.TransmissionId = transmission.Id;
            car.FuelId = fuel.Id;
            car.StatusId = status.Id;

            await _carRepository.AddAsync(car);

            CreatedCarResponse response = _mapper.Map<CreatedCarResponse>(car);
            return response;
        }
    }
}