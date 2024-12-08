using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IVehicleTypeRepository : IAsyncRepository<VehicleType, int>, IRepository<VehicleType, int>
{
}