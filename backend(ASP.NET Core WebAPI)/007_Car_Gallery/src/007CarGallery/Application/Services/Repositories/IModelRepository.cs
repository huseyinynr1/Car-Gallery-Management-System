using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IModelRepository : IAsyncRepository<Model, int>, IRepository<Model, int>
{
}