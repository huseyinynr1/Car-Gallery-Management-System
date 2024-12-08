using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaintenanceStateRepository : IAsyncRepository<MaintenanceState, int>, IRepository<MaintenanceState, int>
{
}