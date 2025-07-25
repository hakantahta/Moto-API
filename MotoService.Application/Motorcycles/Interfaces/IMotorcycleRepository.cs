namespace MotoService.Application.Motorcycles.Interfaces;

using MotoService.Application.Common.Interfaces;
using MotoService.Domain.Entities;

public interface IMotorcycleRepository : IGenericRepository<Motorcycle>
{
    Task<IEnumerable<Motorcycle>> GetByCustomerIdAsync(Guid customerId);
}