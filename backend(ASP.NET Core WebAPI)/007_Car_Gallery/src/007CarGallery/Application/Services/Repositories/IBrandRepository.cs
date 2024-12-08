using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBrandRepository : IAsyncRepository<Brand, int>, IRepository<Brand, int>
{
}