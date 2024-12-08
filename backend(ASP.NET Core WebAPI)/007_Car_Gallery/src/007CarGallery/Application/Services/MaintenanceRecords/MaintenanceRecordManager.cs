using Application.Features.MaintenanceRecords.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MaintenanceRecords;

public class MaintenanceRecordManager : IMaintenanceRecordService
{
    private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;
    private readonly MaintenanceRecordBusinessRules _maintenanceRecordBusinessRules;

    public MaintenanceRecordManager(IMaintenanceRecordRepository maintenanceRecordRepository, MaintenanceRecordBusinessRules maintenanceRecordBusinessRules)
    {
        _maintenanceRecordRepository = maintenanceRecordRepository;
        _maintenanceRecordBusinessRules = maintenanceRecordBusinessRules;
    }

    public async Task<MaintenanceRecord?> GetAsync(
        Expression<Func<MaintenanceRecord, bool>> predicate,
        Func<IQueryable<MaintenanceRecord>, IIncludableQueryable<MaintenanceRecord, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MaintenanceRecord? maintenanceRecord = await _maintenanceRecordRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return maintenanceRecord;
    }

    public async Task<IPaginate<MaintenanceRecord>?> GetListAsync(
        Expression<Func<MaintenanceRecord, bool>>? predicate = null,
        Func<IQueryable<MaintenanceRecord>, IOrderedQueryable<MaintenanceRecord>>? orderBy = null,
        Func<IQueryable<MaintenanceRecord>, IIncludableQueryable<MaintenanceRecord, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MaintenanceRecord> maintenanceRecordList = await _maintenanceRecordRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return maintenanceRecordList;
    }

    public async Task<MaintenanceRecord> AddAsync(MaintenanceRecord maintenanceRecord)
    {
        MaintenanceRecord addedMaintenanceRecord = await _maintenanceRecordRepository.AddAsync(maintenanceRecord);

        return addedMaintenanceRecord;
    }

    public async Task<MaintenanceRecord> UpdateAsync(MaintenanceRecord maintenanceRecord)
    {
        MaintenanceRecord updatedMaintenanceRecord = await _maintenanceRecordRepository.UpdateAsync(maintenanceRecord);

        return updatedMaintenanceRecord;
    }

    public async Task<MaintenanceRecord> DeleteAsync(MaintenanceRecord maintenanceRecord, bool permanent = false)
    {
        MaintenanceRecord deletedMaintenanceRecord = await _maintenanceRecordRepository.DeleteAsync(maintenanceRecord);

        return deletedMaintenanceRecord;
    }

    
}
