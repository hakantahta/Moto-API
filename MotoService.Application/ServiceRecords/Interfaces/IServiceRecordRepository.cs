namespace MotoService.Application.ServiceRecords.Interfaces;

using MotoService.Application.Common.Interfaces;
using MotoService.Domain.Entities;

public interface IServiceRecordRepository : IGenericRepository<ServiceRecord>
{
    Task<IEnumerable<ServiceRecord>> GetByMotorcycleIdAsync(Guid motorcycleId);
}