namespace MotoService.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using MotoService.Application.Motorcycles.Interfaces;
using MotoService.Domain.Entities;
using MotoService.Infrastructure.Persistence;

public class MotorcycleRepository : GenericRepository<Motorcycle>, IMotorcycleRepository
{
    public MotorcycleRepository(MotoServiceDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Motorcycle>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _dbContext.Motorcycles
            .Include(m => m.Customer)
            .Where(m => m.CustomerId == customerId)
            .ToListAsync();
    }

    public override async Task<IEnumerable<Motorcycle>> GetAllAsync()
    {
        return await _dbContext.Motorcycles
            .Include(m => m.Customer)
            .ToListAsync();
    }

    public override async Task<Motorcycle?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Motorcycles
            .Include(m => m.Customer)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}