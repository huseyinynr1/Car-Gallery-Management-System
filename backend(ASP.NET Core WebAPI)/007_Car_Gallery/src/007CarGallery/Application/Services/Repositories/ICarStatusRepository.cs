using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICarStatusRepository : IAsyncRepository<CarStatusEntity, int>, IRepository<CarStatusEntity, int>
{
}