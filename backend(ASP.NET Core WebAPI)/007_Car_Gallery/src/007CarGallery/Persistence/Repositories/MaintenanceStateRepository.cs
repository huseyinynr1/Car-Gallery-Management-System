using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaintenanceStateRepository : EfRepositoryBase<MaintenanceState, int, BaseDbContext>, IMaintenanceStateRepository
{
    public MaintenanceStateRepository(BaseDbContext context) : base(context)
    {
    }
}