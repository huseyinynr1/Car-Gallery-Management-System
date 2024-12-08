using Application.Features.MaintenanceRecords.Constants;
using Application.Features.MaintenanceRecords.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenanceRecords.Constants.MaintenanceRecordsOperationClaims;
using Application.Features.MaintenancePlanningRecords.Rules;

namespace Application.Features.MaintenanceRecords.Commands.Create;

public class CreateMaintenanceRecordCommand : IRequest<CreatedMaintenanceRecordResponse>, ISecuredRequest
{
    public int CarId { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string Type { get; set; }
    public string MaintenanceState { get; set; }
    public string MaintenanceType { get; set; }
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? ComponentCost { get; set; }
    public int? WorkmanshipCost { get; set; }
    public int? DealPrice { get; set; }
    public int? ElapsedTime { get; set; }


    public string[] Roles => [Admin, Write, MaintenanceRecordsOperationClaims.Create];

    public class CreateMaintenanceRecordCommandHandler : IRequestHandler<CreateMaintenanceRecordCommand, CreatedMaintenanceRecordResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IMaintenanceStateRepository _maintenanceStateRepository;
        private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;
        private readonly MaintenanceRecordBusinessRules _maintenanceRecordBusinessRules;

        public CreateMaintenanceRecordCommandHandler(IMapper mapper, IMaintenanceRecordRepository maintenanceRecordRepository, 
            IBrandRepository brandRepository, IModelRepository modelRepository, IMaintenanceStateRepository maintenanceStateRepository, 
            IMaintenanceTypeRepository maintenanceTypeRepository, MaintenanceRecordBusinessRules maintenanceRecordBusinessRules)
        {
            _mapper = mapper;
            _maintenanceRecordRepository = maintenanceRecordRepository;
            _brandRepository = brandRepository;
            _modelRepository = modelRepository;
            _maintenanceStateRepository = maintenanceStateRepository;
            _maintenanceTypeRepository = maintenanceTypeRepository;
            _maintenanceRecordBusinessRules = maintenanceRecordBusinessRules;
        }

        public async Task<CreatedMaintenanceRecordResponse> Handle(CreateMaintenanceRecordCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetAsync(predicate: b => b.Name == request.BrandName);
            await _maintenanceRecordBusinessRules.BrandShouldExistWhenSelected(brand);

            var model = await _modelRepository.GetAsync(predicate: m => m.Name == request.ModelName);
            await _maintenanceRecordBusinessRules.ModelShouldExistWhenSelected(model);

            var maintenanceState = await _maintenanceStateRepository.GetAsync(ms => ms.State == request.MaintenanceState);
            await _maintenanceRecordBusinessRules.MaintenanceStatesShouldExistWhenSelected(maintenanceState);

            var maintenanceType = await _maintenanceTypeRepository.GetAsync(mt => mt.Type == request.MaintenanceType);
            await _maintenanceRecordBusinessRules.MaintenanceTypeShouldExistWhenSelected(maintenanceType);

            MaintenanceRecord maintenanceRecord = _mapper.Map<MaintenanceRecord>(request);

            maintenanceRecord.BrandID = brand.Id;
            maintenanceRecord.ModelID = model.Id;
            maintenanceRecord.MaintenanceStateID = maintenanceState.Id;
            maintenanceRecord.MaintenanceTypeID = maintenanceType.Id;


            await _maintenanceRecordRepository.AddAsync(maintenanceRecord);

            CreatedMaintenanceRecordResponse response = _mapper.Map<CreatedMaintenanceRecordResponse>(maintenanceRecord);
            return response;
        }
    }
}