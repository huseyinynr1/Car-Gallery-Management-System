using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaintenancePlanningRecordRepository : IAsyncRepository<MaintenancePlanningRecord, int>, IRepository<MaintenancePlanningRecord, int>
{
}