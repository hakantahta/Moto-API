namespace MotoService.Application.Motorcycles.Interfaces;

using MotoService.Application.Motorcycles.DTOs;

public interface IMotorcycleService
{
    Task<IEnumerable<MotorcycleDto>> GetAllAsync();
    Task<MotorcycleDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<MotorcycleDto>> GetByCustomerIdAsync(Guid customerId);
    Task<MotorcycleDto> CreateAsync(CreateMotorcycleRequest request);
    Task<MotorcycleDto?> UpdateAsync(Guid id, UpdateMotorcycleRequest request);
    Task<bool> DeleteAsync(Guid id);
}