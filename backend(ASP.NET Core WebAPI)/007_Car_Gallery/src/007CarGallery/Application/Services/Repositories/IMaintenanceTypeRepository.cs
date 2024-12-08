using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaintenanceTypeRepository : IAsyncRepository<MaintenanceType, int>, IRepository<MaintenanceType, int>
{
}