namespace MotoService.Application;

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MotoService.Application.Customers.Interfaces;
using MotoService.Application.Customers.Services;
using MotoService.Application.Motorcycles.Interfaces;
using MotoService.Application.Motorcycles.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        // Register services
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IMotorcycleService, MotorcycleService>();
        
        return services;
    }
}