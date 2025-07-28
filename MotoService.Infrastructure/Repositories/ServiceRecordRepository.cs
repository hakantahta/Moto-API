namespace MotoService.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using MotoService.Application.ServiceRecords.Interfaces;
using MotoService.Domain.Entities;
using MotoService.Infrastructure.Persistence;

public class ServiceRecordRepository : GenericRepository<ServiceRecord>, IServiceRecordRepository
{
    public ServiceRecordRepository(MotoServiceDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<ServiceRecord>> GetByMotorcycleIdAsync(Guid motorcycleId)
    {
        return await _dbContext.ServiceRecords
            .Include(sr => sr.Motorcycle)
            .Where(sr => sr.MotorcycleId == motorcycleId)
            .OrderByDescending(sr => sr.ServiceDate)
            .ToListAsync();
    }

    public override async Task<IEnumerable<ServiceRecord>> GetAllAsync()
    {
        return await _dbContext.ServiceRecords
            .Include(sr => sr.Motorcycle)
            .OrderByDescending(sr => sr.ServiceDate)
            .ToListAsync();
    }

    public override async Task<ServiceRecord?> GetByIdAsync(Guid id)
    {
        return await _dbContext.ServiceRecords
            .Include(sr => sr.Motorcycle)
            .FirstOrDefaultAsync(sr => sr.Id == id);
    }
}