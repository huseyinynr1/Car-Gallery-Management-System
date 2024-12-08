using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using static Application.Features.MaintenancePlanningRecords.Constants.MaintenancePlanningRecordsOperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using AutoMapper;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.MaintenancePlanningRecords.Queries.GetPendingMaintenanceRecordList;
public class GetPendingMaintenanceRecordListQuery : IRequest<GetListResponse<GetListPendingMaintenanceRecordListItemDto>> , ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public string? BrandName { get; set; }
    public string? ModelName { get; set; }
    public string Type { get; set; }
    public string MaintenanceState { get; set; }
    public string MaintenanceType { get; set; }
    public DateTime? Time { get; set; }
    public string[] Roles => [Admin, Read];
}

public class GetPendingMaintenanceRecordListQueryHandler : IRequestHandler<GetPendingMaintenanceRecordListQuery, GetListResponse<GetListPendingMaintenanceRecordListItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IMaintenancePlanningRecordRepository _maintenancePlanningRecordRepository;

    public GetPendingMaintenanceRecordListQueryHandler(IMapper mapper, IMaintenancePlanningRecordRepository maintenancePlanningRecordRepository)
    {
        _mapper = mapper;
        _maintenancePlanningRecordRepository = maintenancePlanningRecordRepository;
    }

    public async Task<GetListResponse<GetListPendingMaintenanceRecordListItemDto>> Handle(GetPendingMaintenanceRecordListQuery request, CancellationToken cancellationToken)
    {
        IPaginate<MaintenancePlanningRecord> maintenancePlanningRecord = await _maintenancePlanningRecordRepository.GetListAsync(
            index: request.PageRequest.PageIndex,
            size: request.PageRequest.PageSize,
            predicate: mpr => (mpr.MaintenanceState.State == "Planlandı" || mpr.MaintenanceState.State == "Beklemede") && (request.BrandName == "" || mpr.Brand.Name == request.BrandName) &&
            (request.ModelName == "" || mpr.Model.Name == request.ModelName) && (request.MaintenanceType == "" || mpr.MaintenanceType.Type == request.MaintenanceType)
            && (request.MaintenanceState == "" || mpr.MaintenanceState.State == request.MaintenanceState)
            && (!request.Time.HasValue || mpr.StartDate >= request.Time.Value),
            include: mpr => mpr.Include(mpr => mpr.Brand)
            .Include(mpr => mpr.Model)
            .Include(mpr => mpr.MaintenanceState)
            .Include(mpr => mpr.MaintenanceType)
            .Include(mpr => mpr.Type),
            orderBy:q => q.OrderByDescending(mpr => mpr.StartDate),
            cancellationToken: cancellationToken);
        GetListResponse<GetListPendingMaintenanceRecordListItemDto> response = _mapper.Map<GetListResponse<GetListPendingMaintenanceRecordListItemDto>>(maintenancePlanningRecord);
        return response;
    }
}
