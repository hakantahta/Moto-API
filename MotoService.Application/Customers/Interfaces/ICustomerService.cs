namespace MotoService.Application.Customers.Interfaces;

using MotoService.Application.Customers.DTOs;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<CustomerDto?> GetByIdAsync(Guid id);
    Task<CustomerDto> CreateAsync(CreateCustomerRequest request);
    Task<CustomerDto?> UpdateAsync(Guid id, UpdateCustomerRequest request);
    Task<bool> DeleteAsync(Guid id);
}