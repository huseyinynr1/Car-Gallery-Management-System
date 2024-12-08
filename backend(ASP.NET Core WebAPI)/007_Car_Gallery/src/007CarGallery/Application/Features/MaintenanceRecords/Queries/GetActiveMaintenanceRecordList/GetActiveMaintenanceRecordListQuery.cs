using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using static Application.Features.MaintenanceRecords.Constants.MaintenanceRecordsOperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.MaintenanceRecords.Queries.GetActiveMaintenanceRecordList;
public class GetActiveMaintenanceRecordListQuery : IRequest<GetListResponse<GetListActiveMaintenanceRecordListItemDto>>, ISecuredRequest
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
public class GetActiveMaintenanceRecordListQueryHandler : IRequestHandler<GetActiveMaintenanceRecordListQuery, GetListResponse<GetListActiveMaintenanceRecordListItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;

    public GetActiveMaintenanceRecordListQueryHandler(IMapper mapper, IMaintenanceRecordRepository maintenanceRecordRepository)
    {
        _mapper = mapper;
        _maintenanceRecordRepository = maintenanceRecordRepository;
    }

    public async Task<GetListResponse<GetListActiveMaintenanceRecordListItemDto>> Handle(GetActiveMaintenanceRecordListQuery request, CancellationToken cancellationToken)
    {
        IPaginate<MaintenanceRecord> maintenanceRecord = await _maintenanceRecordRepository.GetListAsync(
            index: request.PageRequest.PageIndex,
            size: request.PageRequest.PageSize,
            predicate: mr => (mr.MaintenanceState.State == "Başladı" || mr.MaintenanceState.State == "Devam Ediyor"
            || mr.MaintenanceState.State == "Test Ediliyor") && (request.BrandName == "" || mr.Brand.Name == request.BrandName) &&
            (request.ModelName == "" || mr.Model.Name == request.ModelName) && (request.MaintenanceType == "" || mr.MaintenanceType.Type == request.MaintenanceType)
            && (request.MaintenanceState == "" || mr.MaintenanceState.State == request.MaintenanceState)
            && (!request.Time.HasValue || mr.StartDate >= request.Time.Value)
            ,
            orderBy: q => q.OrderByDescending(mr => mr.StartDate),
            include: mr => mr.Include(mr => mr.Brand).Include(mr => mr.Model).Include(mr => mr.Type).Include(mr => mr.MaintenanceState).Include(mr => mr.MaintenanceType),
            cancellationToken: cancellationToken);
        GetListResponse<GetListActiveMaintenanceRecordListItemDto> response = _mapper.Map<GetListResponse<GetListActiveMaintenanceRecordListItemDto>>(maintenanceRecord);
        return response;
    }
}
