namespace MotoService.Application;

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MotoService.Application.Customers.Interfaces;
using MotoService.Application.Customers.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        // Register services
        services.AddScoped<ICustomerService, CustomerService>();
        
        return services;
    }
}