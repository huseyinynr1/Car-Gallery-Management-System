using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITransmissionRepository : IAsyncRepository<Transmission, int>, IRepository<Transmission, int>
{
}