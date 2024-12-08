using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using System.Linq.Expressions;

namespace Application.Services.Repositories;

public interface ICarRepository : IAsyncRepository<Car, int>, IRepository<Car, int>
{
    Task<int> GetTotalCarCountAsync(Expression<Func<Car, bool>> filter = null, CancellationToken cancellationToken = default(CancellationToken));

    // Sadece belirli bir markaya g�re araba say�s�n� alan metod

    Task<int> GetCarsCountByBrandNameAsync(string brandName);
}