namespace MotoService.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using MotoService.Domain.Entities;
using MotoService.Infrastructure.Persistence.Configurations;

public class MotoServiceDbContext : DbContext
{
    public MotoServiceDbContext(DbContextOptions<MotoServiceDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Motorcycle> Motorcycles { get; set; }
    public DbSet<ServiceRecord> ServiceRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new MotorcycleConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceRecordConfiguration());
    }
}