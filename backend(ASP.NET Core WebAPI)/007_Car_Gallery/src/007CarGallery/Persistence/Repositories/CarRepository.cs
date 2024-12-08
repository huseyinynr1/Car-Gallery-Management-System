using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class CarRepository : EfRepositoryBase<Car, int, BaseDbContext>, ICarRepository
{
    public CarRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<int> GetCarsCountByBrandNameAsync(string brandName)
    {
        return await Context.Cars.Where(c => c.Brand.Name == brandName).CountAsync();
    }

    public Task<int> GetTotalCarCountAsync(Expression<Func<Car, bool>> filter = null, CancellationToken cancellationToken = default)
    {
        if (filter == null)
        {
            return Context.Cars.CountAsync(cancellationToken);
        }
        else
        {
            return Context.Cars.Where(filter).CountAsync(cancellationToken);
        }
    }
}