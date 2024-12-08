using Application.Features.MaintenancePlanningRecords.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaintenancePlanningRecords;

public class MaintenancePlanningRecordManager : IMaintenancePlanningRecordService
{
    private readonly IMaintenancePlanningRecordRepository _maintenancePlanningRecordRepository;
    private readonly MaintenancePlanningRecordBusinessRules _maintenancePlanningRecordBusinessRules;

    public MaintenancePlanningRecordManager(IMaintenancePlanningRecordRepository maintenancePlanningRecordRepository, MaintenancePlanningRecordBusinessRules maintenancePlanningRecordBusinessRules)
    {
        _maintenancePlanningRecordRepository = maintenancePlanningRecordRepository;
        _maintenancePlanningRecordBusinessRules = maintenancePlanningRecordBusinessRules;
    }

    public async Task<MaintenancePlanningRecord?> GetAsync(
        Expression<Func<MaintenancePlanningRecord, bool>> predicate,
        Func<IQueryable<MaintenancePlanningRecord>, IIncludableQueryable<MaintenancePlanningRecord, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaintenancePlanningRecord? maintenancePlanningRecord = await _maintenancePlanningRecordRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return maintenancePlanningRecord;
    }

    public async Task<IPaginate<MaintenancePlanningRecord>?> GetListAsync(
        Expression<Func<MaintenancePlanningRecord, bool>>? predicate = null,
        Func<IQueryable<MaintenancePlanningRecord>, IOrderedQueryable<MaintenancePlanningRecord>>? orderBy = null,
        Func<IQueryable<MaintenancePlanningRecord>, IIncludableQueryable<MaintenancePlanningRecord, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaintenancePlanningRecord> maintenancePlanningRecordList = await _maintenancePlanningRecordRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return maintenancePlanningRecordList;
    }

    public async Task<MaintenancePlanningRecord> AddAsync(MaintenancePlanningRecord maintenancePlanningRecord)
    {
        MaintenancePlanningRecord addedMaintenancePlanningRecord = await _maintenancePlanningRecordRepository.AddAsync(maintenancePlanningRecord);

        return addedMaintenancePlanningRecord;
    }

    public async Task<MaintenancePlanningRecord> UpdateAsync(MaintenancePlanningRecord maintenancePlanningRecord)
    {
        MaintenancePlanningRecord updatedMaintenancePlanningRecord = await _maintenancePlanningRecordRepository.UpdateAsync(maintenancePlanningRecord);

        return updatedMaintenancePlanningRecord;
    }

    public async Task<MaintenancePlanningRecord> DeleteAsync(MaintenancePlanningRecord maintenancePlanningRecord, bool permanent = false)
    {
        MaintenancePlanningRecord deletedMaintenancePlanningRecord = await _maintenancePlanningRecordRepository.DeleteAsync(maintenancePlanningRecord);

        return deletedMaintenancePlanningRecord;
    }
}
