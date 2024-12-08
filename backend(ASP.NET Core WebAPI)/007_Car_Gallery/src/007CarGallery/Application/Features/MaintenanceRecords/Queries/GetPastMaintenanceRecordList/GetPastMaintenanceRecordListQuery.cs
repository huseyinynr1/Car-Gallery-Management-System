using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.MaintenanceRecords.Constants.MaintenanceRecordsOperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetPastMaintenanceRecordList;
public class GetPastMaintenanceRecordListQuery : IRequest<GetListResponse<GetListPastMaintenanceRecordListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public string? BrandName { get; set; }
    public string? ModelName { get; set; }
    public string Type { get; set; }
    public string? MaintenanceState { get; set; }
    public string? MaintenanceType { get; set; }
    public DateTime? Time { get; set; }
    public int? MinDealPrice { get; set; }
    public int? MaxDealPrice { get; set; }
    public string[] Roles => [Admin, Read];
}

public class GetPastMaintenanceRecordListQueryHandler : IRequestHandler<GetPastMaintenanceRecordListQuery, GetListResponse<GetListPastMaintenanceRecordListItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;

    public GetPastMaintenanceRecordListQueryHandler(IMapper mapper, IMaintenanceRecordRepository maintenanceRecordRepository)
    {
        _mapper = mapper;
        _maintenanceRecordRepository = maintenanceRecordRepository;
    }

    public async Task<GetListResponse<GetListPastMaintenanceRecordListItemDto>> Handle(GetPastMaintenanceRecordListQuery request, CancellationToken cancellationToken)
    {
        IPaginate<MaintenanceRecord> maintenanceRecord = await _maintenanceRecordRepository.GetListAsync(
            index: request.PageRequest.PageIndex,
            size: request.PageRequest.PageSize,
            predicate: mr => (mr.MaintenanceState.State == "Tamamlandı" || mr.MaintenanceState.State == "Teslim Edildi") && (request.BrandName == "" || mr.Brand.Name == request.BrandName) &&
            (request.ModelName == "" || mr.Model.Name == request.ModelName) && (request.MaintenanceType == "" || mr.MaintenanceType.Type == request.MaintenanceType)
            && (request.MaintenanceState == "" || mr.MaintenanceState.State == request.MaintenanceState)
            && (!request.Time.HasValue || mr.StartDate >= request.Time.Value)
            && (!request.MinDealPrice.HasValue || mr.DealPrice >= request.MinDealPrice.Value)
            && (!request.MaxDealPrice.HasValue || mr.DealPrice <= request.MaxDealPrice.Value),
            include: mr => mr.Include(mr => mr.MaintenanceState)
            .Include(mr => mr.MaintenanceType)
            .Include(mr => mr.Brand)
            .Include(mr => mr.Model)
            .Include(mr => mr.Type),
            orderBy: q => q.OrderByDescending(mr => mr.EndDate),
            cancellationToken: cancellationToken
            );

        GetListResponse<GetListPastMaintenanceRecordListItemDto> response = _mapper.Map<GetListResponse<GetListPastMaintenanceRecordListItemDto>>(maintenanceRecord);
        return response;
    }
}
