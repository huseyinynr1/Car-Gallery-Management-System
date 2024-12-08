using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CarStatusHistoryRepository : EfRepositoryBase<CarStatusHistory, int, BaseDbContext>, ICarStatusHistoryRepository
{
    public CarStatusHistoryRepository(BaseDbContext context) : base(context)
    {
    }
}