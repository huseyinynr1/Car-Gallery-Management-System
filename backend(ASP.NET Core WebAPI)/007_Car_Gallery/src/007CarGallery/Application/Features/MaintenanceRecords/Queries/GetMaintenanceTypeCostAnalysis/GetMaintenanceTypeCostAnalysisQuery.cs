using Application.Services.Repositories;
using MediatR;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetMaintenanceTypeCostAnalysis;
public class GetMaintenanceTypeCostAnalysisQuery : IRequest<GetListResponse<GetListGetMaintenanceTypeCostAnalysisItemDto>>
{
}

public class GetMaintenanceTypeCostAnalysisQueryHandler : IRequestHandler<GetMaintenanceTypeCostAnalysisQuery, GetListResponse<GetListGetMaintenanceTypeCostAnalysisItemDto>>
{
    private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;
    private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;
    private readonly IBrandRepository _brandRepository;

    public GetMaintenanceTypeCostAnalysisQueryHandler(IMaintenanceRecordRepository maintenanceRecordRepository, 
        IMaintenanceTypeRepository maintenanceTypeRepository, IBrandRepository brandRepository)
    {
        _maintenanceRecordRepository = maintenanceRecordRepository;
        _maintenanceTypeRepository = maintenanceTypeRepository;
        _brandRepository = brandRepository;
    }

    public async Task<GetListResponse<GetListGetMaintenanceTypeCostAnalysisItemDto>> Handle(GetMaintenanceTypeCostAnalysisQuery request, CancellationToken cancellationToken)
    {
        var responses = new GetListResponse<GetListGetMaintenanceTypeCostAnalysisItemDto>
        {
            Items = new List<GetListGetMaintenanceTypeCostAnalysisItemDto>()
        };


        var types = await _maintenanceTypeRepository.GetListAsync();

        if(types == null || !types.Items.Any()) 
        {
            return responses;
        };



        foreach (var type in types.Items)
        {
            int cost = await _maintenanceRecordRepository.GetTotalCostAsync(mr => mr.MaintenanceTypeID == type.Id, cancellationToken);
            int count = await _maintenanceRecordRepository.GetDistinctCountAsync(predicate : mr => mr.MaintenanceTypeID == type.Id,
                distinctProperty: mr => mr.BrandID,
                cancellationToken); 

            responses.Items.Add(new GetListGetMaintenanceTypeCostAnalysisItemDto
            {
                Type = type.Type,
                Cost = cost,
                Count = count,
            });

        }


        return responses;
    }
}
