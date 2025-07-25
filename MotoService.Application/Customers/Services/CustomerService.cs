namespace MotoService.Application.Customers.Services;

using AutoMapper;
using MotoService.Application.Customers.DTOs;
using MotoService.Application.Customers.Interfaces;
using MotoService.Domain.Entities;

public class CustomerService : ICustomerService
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomerDto>>(customers);
    }

    public async Task<CustomerDto?> GetByIdAsync(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return customer != null ? _mapper.Map<CustomerDto>(customer) : null;
    }

    public async Task<CustomerDto> CreateAsync(CreateCustomerRequest request)
    {
        var customer = _mapper.Map<Customer>(request);
        customer.Id = Guid.NewGuid();
        customer.CreatedAt = DateTime.UtcNow;
        
        await _customerRepository.AddAsync(customer);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<CustomerDto?> UpdateAsync(Guid id, UpdateCustomerRequest request)
    {
        var existingCustomer = await _customerRepository.GetByIdAsync(id);
        if (existingCustomer == null)
            return null;
        
        _mapper.Map(request, existingCustomer);
        await _customerRepository.UpdateAsync(existingCustomer);
        return _mapper.Map<CustomerDto>(existingCustomer);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
            return false;
        
        await _customerRepository.DeleteAsync(customer);
        return true;
    }
}