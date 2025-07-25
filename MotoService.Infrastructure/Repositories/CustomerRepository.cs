namespace MotoService.Infrastructure.Repositories;

using MotoService.Application.Customers.Interfaces;
using MotoService.Domain.Entities;
using MotoService.Infrastructure.Persistence;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(MotoServiceDbContext dbContext) : base(dbContext)
    {
    }

    // Özel müşteri repository metotları buraya eklenebilir
}