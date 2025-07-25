namespace MotoService.Application.Motorcycles.Services;

using AutoMapper;
using MotoService.Application.Motorcycles.DTOs;
using MotoService.Application.Motorcycles.Interfaces;
using MotoService.Domain.Entities;

public class MotorcycleService : IMotorcycleService
{
    private readonly IMotorcycleRepository _motorcycleRepository;
    private readonly IMapper _mapper;

    public MotorcycleService(IMotorcycleRepository motorcycleRepository, IMapper mapper)
    {
        _motorcycleRepository = motorcycleRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MotorcycleDto>> GetAllAsync()
    {
        var motorcycles = await _motorcycleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MotorcycleDto>>(motorcycles);
    }

    public async Task<MotorcycleDto?> GetByIdAsync(Guid id)
    {
        var motorcycle = await _motorcycleRepository.GetByIdAsync(id);
        return motorcycle != null ? _mapper.Map<MotorcycleDto>(motorcycle) : null;
    }

    public async Task<IEnumerable<MotorcycleDto>> GetByCustomerIdAsync(Guid customerId)
    {
        var motorcycles = await _motorcycleRepository.GetByCustomerIdAsync(customerId);
        return _mapper.Map<IEnumerable<MotorcycleDto>>(motorcycles);
    }

    public async Task<MotorcycleDto> CreateAsync(CreateMotorcycleRequest request)
    {
        var motorcycle = _mapper.Map<Motorcycle>(request);
        await _motorcycleRepository.AddAsync(motorcycle);
        return _mapper.Map<MotorcycleDto>(motorcycle);
    }

    public async Task<MotorcycleDto?> UpdateAsync(Guid id, UpdateMotorcycleRequest request)
    {
        var motorcycle = await _motorcycleRepository.GetByIdAsync(id);
        if (motorcycle == null) return null;

        _mapper.Map(request, motorcycle);
        await _motorcycleRepository.UpdateAsync(motorcycle);
        return _mapper.Map<MotorcycleDto>(motorcycle);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var motorcycle = await _motorcycleRepository.GetByIdAsync(id);
        if (motorcycle == null) return false;

        await _motorcycleRepository.DeleteAsync(motorcycle);
        return true;
    }
}