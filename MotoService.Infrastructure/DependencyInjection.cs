namespace MotoService.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotoService.Application.Common.Interfaces;
using MotoService.Application.Customers.Interfaces;
using MotoService.Infrastructure.Persistence;
using MotoService.Infrastructure.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<MotoServiceDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(MotoServiceDbContext).Assembly.FullName)));

        // Repositories
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}