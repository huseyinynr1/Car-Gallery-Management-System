using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaintenancePlanningRecordRepository : EfRepositoryBase<MaintenancePlanningRecord, int, BaseDbContext>, IMaintenancePlanningRecordRepository
{
    public MaintenancePlanningRecordRepository(BaseDbContext context) : base(context)
    {
    }
}