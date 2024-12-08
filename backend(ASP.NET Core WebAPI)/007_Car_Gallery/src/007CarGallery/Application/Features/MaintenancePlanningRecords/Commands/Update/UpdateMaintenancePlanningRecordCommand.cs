using Application.Features.MaintenancePlanningRecords.Constants;
using Application.Features.MaintenancePlanningRecords.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenancePlanningRecords.Constants.MaintenancePlanningRecordsOperationClaims;

namespace Application.Features.MaintenancePlanningRecords.Commands.Update;

public class UpdateMaintenancePlanningRecordCommand : IRequest<UpdatedMaintenancePlanningRecordResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime Enddate { get; set; }
    public string Type { get; set; }
    public string MaintenanceState { get; set; }
    public string MaintenanceType { get; set; }
    public int EstimatedElapsedTime { get; set; }
    public int EstimatedCost { get; set; }
    public int EstimatedComponentCost { get; set; }
    public int EstimatedWorkmanshipCost { get; set; }

    public string[] Roles => [Admin, Write, MaintenancePlanningRecordsOperationClaims.Update];

    public class UpdateMaintenancePlanningRecordCommandHandler : IRequestHandler<UpdateMaintenancePlanningRecordCommand, UpdatedMaintenancePlanningRecordResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenancePlanningRecordRepository _maintenancePlanningRecordRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IMaintenanceStateRepository _maintenanceStateRepository;
        private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;
        private readonly MaintenancePlanningRecordBusinessRules _maintenancePlanningRecordBusinessRules;

        public UpdateMaintenancePlanningRecordCommandHandler(IMapper mapper, IMaintenancePlanningRecordRepository 
            maintenancePlanningRecordRepository, IBrandRepository brandRepository, IModelRepository modelRepository, 
            IMaintenanceStateRepository maintenanceStateRepository, IMaintenanceTypeRepository maintenanceTypeRepository, 
            MaintenancePlanningRecordBusinessRules maintenancePlanningRecordBusinessRules)
        {
            _mapper = mapper;
            _maintenancePlanningRecordRepository = maintenancePlanningRecordRepository;
            _brandRepository = brandRepository;
            _modelRepository = modelRepository;
            _maintenanceStateRepository = maintenanceStateRepository;
            _maintenanceTypeRepository = maintenanceTypeRepository;
            _maintenancePlanningRecordBusinessRules = maintenancePlanningRecordBusinessRules;
        }

        public async Task<UpdatedMaintenancePlanningRecordResponse> Handle(UpdateMaintenancePlanningRecordCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetAsync(b => b.Name == request.BrandName, cancellationToken: cancellationToken);
            await _maintenancePlanningRecordBusinessRules.BrandShouldExistWhenSelected(brand);

            var model = await _modelRepository.GetAsync(predicate: m => m.Name == request.ModelName);
            await _maintenancePlanningRecordBusinessRules.ModelShouldExistWhenSelected(model);

            var maintenanceState = await _maintenanceStateRepository.GetAsync(ms => ms.State == request.MaintenanceState, 
                cancellationToken: cancellationToken);
            await _maintenancePlanningRecordBusinessRules.MaintenanceStatesShouldExistWhenSelected(maintenanceState);

            var maintenanceType = await _maintenanceTypeRepository.GetAsync(mt => mt.Type == request.MaintenanceType, 
                cancellationToken: cancellationToken);
            await _maintenancePlanningRecordBusinessRules.MaintenanceTypeShouldExistWhenSelected(maintenanceType);

            MaintenancePlanningRecord? maintenancePlanningRecord = await _maintenancePlanningRecordRepository
                .GetAsync(predicate: mpr => mpr.Id == request.Id, cancellationToken: cancellationToken);
            await _maintenancePlanningRecordBusinessRules.MaintenancePlanningRecordShouldExistWhenSelected(maintenancePlanningRecord);
            maintenancePlanningRecord = _mapper.Map(request, maintenancePlanningRecord);

            maintenancePlanningRecord.BrandID = brand.Id;
            maintenancePlanningRecord.ModelID = brand.Id;
            maintenancePlanningRecord.MaintenanceStateID = maintenanceState.Id;
            maintenancePlanningRecord.MaintenanceTypeID = maintenanceType.Id;

            await _maintenancePlanningRecordRepository.UpdateAsync(maintenancePlanningRecord!);

            UpdatedMaintenancePlanningRecordResponse response = _mapper.Map<UpdatedMaintenancePlanningRecordResponse>(maintenancePlanningRecord);
            return response;
        }
    }
}