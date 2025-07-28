namespace MotoService.Application.ServiceRecords.Interfaces;

using MotoService.Application.ServiceRecords.DTOs;

public interface IServiceRecordService
{
    Task<IEnumerable<ServiceRecordDto>> GetByMotorcycleIdAsync(Guid motorcycleId);
    Task<ServiceRecordDto> CreateAsync(CreateServiceRecordRequest request);
    Task<ServiceRecordDto?> UpdateAsync(Guid id, UpdateServiceRecordRequest request);
    Task<bool> DeleteAsync(Guid id);
}