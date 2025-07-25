namespace MotoService.Application.Common.Mapping;

using AutoMapper;
using MotoService.Application.Customers.DTOs;
using MotoService.Application.Motorcycles.DTOs;
using MotoService.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Customer mappings
        CreateMap<Customer, CustomerDto>();
        CreateMap<CreateCustomerRequest, Customer>();
        CreateMap<UpdateCustomerRequest, Customer>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // Motorcycle mappings
        CreateMap<Motorcycle, MotorcycleDto>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.Name : string.Empty));
        CreateMap<CreateMotorcycleRequest, Motorcycle>();
        CreateMap<UpdateMotorcycleRequest, Motorcycle>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}