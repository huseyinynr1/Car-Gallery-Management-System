using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class VehicleTypeRepository : EfRepositoryBase<VehicleType, int, BaseDbContext>, IVehicleTypeRepository
{
    public VehicleTypeRepository(BaseDbContext context) : base(context)
    {
    }
}