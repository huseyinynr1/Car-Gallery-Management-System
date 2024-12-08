using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CarStatusRepository : EfRepositoryBase<CarStatusEntity, int, BaseDbContext>, ICarStatusRepository
{
    public CarStatusRepository(BaseDbContext context) : base(context)
    {
    }
}