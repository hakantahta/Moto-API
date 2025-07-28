namespace MotoService.Application.ServiceRecords.Services;

using AutoMapper;
using MotoService.Application.ServiceRecords.DTOs;
using MotoService.Application.ServiceRecords.Interfaces;
using MotoService.Domain.Entities;

public class ServiceRecordService : IServiceRecordService
{
    private readonly IServiceRecordRepository _serviceRecordRepository;
    private readonly IMapper _mapper;

    public ServiceRecordService(IServiceRecordRepository serviceRecordRepository, IMapper mapper)
    {
        _serviceRecordRepository = serviceRecordRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ServiceRecordDto>> GetByMotorcycleIdAsync(Guid motorcycleId)
    {
        var serviceRecords = await _serviceRecordRepository.GetByMotorcycleIdAsync(motorcycleId);
        return _mapper.Map<IEnumerable<ServiceRecordDto>>(serviceRecords);
    }

    public async Task<ServiceRecordDto> CreateAsync(CreateServiceRecordRequest request)
    {
        var serviceRecord = _mapper.Map<ServiceRecord>(request);
        await _serviceRecordRepository.AddAsync(serviceRecord);
        return _mapper.Map<ServiceRecordDto>(serviceRecord);
    }

    public async Task<ServiceRecordDto?> UpdateAsync(Guid id, UpdateServiceRecordRequest request)
    {
        var serviceRecord = await _serviceRecordRepository.GetByIdAsync(id);
        if (serviceRecord == null) return null;

        _mapper.Map(request, serviceRecord);
        await _serviceRecordRepository.UpdateAsync(serviceRecord);
        return _mapper.Map<ServiceRecordDto>(serviceRecord);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var serviceRecord = await _serviceRecordRepository.GetByIdAsync(id);
        if (serviceRecord == null) return false;

        await _serviceRecordRepository.DeleteAsync(serviceRecord);
        return true;
    }
}