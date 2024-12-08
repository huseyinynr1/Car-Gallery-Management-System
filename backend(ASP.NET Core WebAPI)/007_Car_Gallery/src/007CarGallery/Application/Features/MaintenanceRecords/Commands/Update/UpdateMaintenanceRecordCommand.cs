using Application.Features.MaintenanceRecords.Constants;
using Application.Features.MaintenanceRecords.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenanceRecords.Constants.MaintenanceRecordsOperationClaims;

namespace Application.Features.MaintenanceRecords.Commands.Update;

public class UpdateMaintenanceRecordCommand : IRequest<UpdatedMaintenanceRecordResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string Type { get; set; }
    public string MaintenanceState { get; set; }
    public string MaintenanceType { get; set; }
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int ComponentCost { get; set; }
    public int WorkmanshipCost { get; set; }
    public int DealPrice { get; set; }
    public int ElapsedTime { get; set; }

    public string[] Roles => [Admin, Write, MaintenanceRecordsOperationClaims.Update];

    public class UpdateMaintenanceRecordCommandHandler : IRequestHandler<UpdateMaintenanceRecordCommand, UpdatedMaintenanceRecordResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;
        private readonly MaintenanceRecordBusinessRules _maintenanceRecordBusinessRules;
        private readonly IBrandRepository _brandRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IMaintenanceStateRepository _maintenanceStateRepository;
        private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;

        public UpdateMaintenanceRecordCommandHandler(IMapper mapper, IMaintenanceRecordRepository maintenanceRecordRepository, 
            MaintenanceRecordBusinessRules maintenanceRecordBusinessRules, IBrandRepository brandRepository, 
            IModelRepository modelRepository, IMaintenanceStateRepository maintenanceStateRepository, 
            IMaintenanceTypeRepository maintenanceTypeRepository)
        {
            _mapper = mapper;
            _maintenanceRecordRepository = maintenanceRecordRepository;
            _maintenanceRecordBusinessRules = maintenanceRecordBusinessRules;
            _brandRepository = brandRepository;
            _modelRepository = modelRepository;
            _maintenanceStateRepository = maintenanceStateRepository;
            _maintenanceTypeRepository = maintenanceTypeRepository;
        }

        public async Task<UpdatedMaintenanceRecordResponse> Handle(UpdateMaintenanceRecordCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetAsync(predicate: b => b.Name == request.BrandName);
            await _maintenanceRecordBusinessRules.BrandShouldExistWhenSelected(brand);

            var model = await _modelRepository.GetAsync(predicate: m => m.Name == request.ModelName);
            await _maintenanceRecordBusinessRules.ModelShouldExistWhenSelected(model);

            var maintenanceState = await _maintenanceStateRepository.GetAsync(ms => ms.State == request.MaintenanceState);
            await _maintenanceRecordBusinessRules.MaintenanceStatesShouldExistWhenSelected(maintenanceState);

            var maintenanceType = await _maintenanceTypeRepository.GetAsync(mt => mt.Type == request.MaintenanceType);
            await _maintenanceRecordBusinessRules.MaintenanceTypeShouldExistWhenSelected(maintenanceType);

            MaintenanceRecord? maintenanceRecord = await _maintenanceRecordRepository.GetAsync(predicate: mr => mr.ChassisNo == request.ChassisNo, cancellationToken: cancellationToken);
            await _maintenanceRecordBusinessRules.MaintenanceRecordShouldExistWhenSelected(maintenanceRecord);
            maintenanceRecord = _mapper.Map(request, maintenanceRecord);

            maintenanceRecord.BrandID = brand.Id;
            maintenanceRecord.ModelID = model.Id;
            maintenanceRecord.MaintenanceStateID = maintenanceState.Id;
            maintenanceRecord.MaintenanceTypeID = maintenanceType.Id;

            await _maintenanceRecordRepository.UpdateAsync(maintenanceRecord!);

            UpdatedMaintenanceRecordResponse response = _mapper.Map<UpdatedMaintenanceRecordResponse>(maintenanceRecord);
            return response;
        }
    }
}