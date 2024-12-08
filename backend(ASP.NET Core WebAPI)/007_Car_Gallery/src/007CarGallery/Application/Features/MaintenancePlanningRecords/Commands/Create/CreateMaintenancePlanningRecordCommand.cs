using Application.Features.MaintenancePlanningRecords.Constants;
using Application.Features.MaintenancePlanningRecords.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenancePlanningRecords.Constants.MaintenancePlanningRecordsOperationClaims;
using Application.Features.Cars.Rules;
using Application.Features.MaintenanceRecords.Rules;

namespace Application.Features.MaintenancePlanningRecords.Commands.Create;

public class CreateMaintenancePlanningRecordCommand : IRequest<CreatedMaintenancePlanningRecordResponse>, ISecuredRequest
{
    public int CarId { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string Type { get; set; }
    public string MaintenanceState { get; set; }
    public string MaintenanceType { get; set; }
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime Enddate { get; set; }
    public int EstimatedElapsedTime { get; set; }
    public int? EstimatedCost { get; set; }
    public int? EstimatedComponentCost { get; set; }
    public int? EstimatedWorkmanshipCost { get; set; }

    public string[] Roles => [Admin, Write, MaintenancePlanningRecordsOperationClaims.Create];

    public class CreateMaintenancePlanningRecordCommandHandler : IRequestHandler<CreateMaintenancePlanningRecordCommand, CreatedMaintenancePlanningRecordResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenancePlanningRecordRepository _maintenancePlanningRecordRepository;
        private readonly MaintenancePlanningRecordBusinessRules _maintenancePlanningRecordBusinessRules;
        private readonly IBrandRepository _brandRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IMaintenanceStateRepository _maintenanceStateRepository;
        private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;

        public CreateMaintenancePlanningRecordCommandHandler(IMapper mapper, IMaintenancePlanningRecordRepository maintenancePlanningRecordRepository,
            MaintenancePlanningRecordBusinessRules maintenancePlanningRecordBusinessRules, IBrandRepository brandRepository, 
            IModelRepository modelRepository, IMaintenanceStateRepository maintenanceStateRepository, 
            IMaintenanceTypeRepository maintenanceTypeRepository)
        {
            _mapper = mapper;
            _maintenancePlanningRecordRepository = maintenancePlanningRecordRepository;
            _maintenancePlanningRecordBusinessRules = maintenancePlanningRecordBusinessRules;
            _brandRepository = brandRepository;
            _modelRepository = modelRepository;
            _maintenanceStateRepository = maintenanceStateRepository;
            _maintenanceTypeRepository = maintenanceTypeRepository;
        }

        public async Task<CreatedMaintenancePlanningRecordResponse> Handle(CreateMaintenancePlanningRecordCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetAsync(predicate: b => b.Name == request.BrandName);
            await _maintenancePlanningRecordBusinessRules.BrandShouldExistWhenSelected(brand);

            var model = await _modelRepository.GetAsync(predicate: m => m.Name == request.ModelName);
            await _maintenancePlanningRecordBusinessRules.ModelShouldExistWhenSelected(model);

            var maintenanceState = await _maintenanceStateRepository.GetAsync(ms => ms.State == request.MaintenanceState);
            await _maintenancePlanningRecordBusinessRules.MaintenanceStatesShouldExistWhenSelected(maintenanceState);

            var maintenanceType = await _maintenanceTypeRepository.GetAsync(mt => mt.Type == request.MaintenanceType);
            await _maintenancePlanningRecordBusinessRules.MaintenanceTypeShouldExistWhenSelected(maintenanceType);


            MaintenancePlanningRecord maintenancePlanningRecord = _mapper.Map<MaintenancePlanningRecord>(request);

            maintenancePlanningRecord.BrandID = brand.Id;
            maintenancePlanningRecord.ModelID = brand.Id;
            maintenancePlanningRecord.MaintenanceStateID = maintenanceState.Id;
            maintenancePlanningRecord.MaintenanceTypeID = maintenanceType.Id;

            await _maintenancePlanningRecordRepository.AddAsync(maintenancePlanningRecord);

            CreatedMaintenancePlanningRecordResponse response = _mapper.Map<CreatedMaintenancePlanningRecordResponse>(maintenancePlanningRecord);
            return response;
        }
    }
}