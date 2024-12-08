using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaintenanceTypeRepository : EfRepositoryBase<MaintenanceType, int, BaseDbContext>, IMaintenanceTypeRepository
{
    public MaintenanceTypeRepository(BaseDbContext context) : base(context)
    {
    }
}