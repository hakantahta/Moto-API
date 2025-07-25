namespace MotoService.Application.Customers.Interfaces;

using MotoService.Application.Common.Interfaces;
using MotoService.Domain.Entities;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    // Özel müşteri repository metotları buraya eklenebilir
}