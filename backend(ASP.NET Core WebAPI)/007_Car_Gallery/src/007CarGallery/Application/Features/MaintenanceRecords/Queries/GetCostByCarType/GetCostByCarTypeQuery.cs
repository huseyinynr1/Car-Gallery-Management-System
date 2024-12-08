using Application.Features.MaintenanceRecords.Queries.GetCostByBrand;
using Application.Services.Repositories;
using MediatR;
using NArchitecture.Core.Application.Responses;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetCostByCarType;
public class GetCostByCarTypeQuery : MediatR.IRequest<GetListResponse<GetListGetCostByCarTypeItemDto>>
{
}

public class GetCostByCarTypeQueryHandler : IRequestHandler<GetCostByCarTypeQuery, GetListResponse<GetListGetCostByCarTypeItemDto>>
{
    private readonly IVehicleTypeRepository _vehicleTypeRepository;
    private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;

    public GetCostByCarTypeQueryHandler(IVehicleTypeRepository vehicleTypeRepository, IMaintenanceRecordRepository maintenanceRecordRepository)
    {
        _vehicleTypeRepository = vehicleTypeRepository;
        _maintenanceRecordRepository = maintenanceRecordRepository;
    }

    public async Task<GetListResponse<GetListGetCostByCarTypeItemDto>> Handle(GetCostByCarTypeQuery request, CancellationToken cancellationToken)
    {
        var response = new GetListResponse<GetListGetCostByCarTypeItemDto>
        {
            Items = new List<GetListGetCostByCarTypeItemDto>()
        };

        var types = await _vehicleTypeRepository.GetListAsync();
        if (types == null || !types.Items.Any())
        {
            return response;
        }

        foreach (var type in types.Items)
        {
            int cost = await _maintenanceRecordRepository.GetTotalCostAsync(mr => mr.TypeID == type.Id);

            response.Items.Add(new GetListGetCostByCarTypeItemDto { Cost = cost, Type = type.Type });
        }

        return response;
    }
}
