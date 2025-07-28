using Microsoft.AspNetCore.Mvc;
using MotoService.Application.Common;
using MotoService.Application.ServiceRecords.DTOs;
using MotoService.Application.ServiceRecords.Interfaces;

namespace MotoService.API.Controllers;

[ApiController]
[Route("api/records")]
public class ServiceRecordsController : ControllerBase
{
    private readonly IServiceRecordService _serviceRecordService;

    public ServiceRecordsController(IServiceRecordService serviceRecordService)
    {
        _serviceRecordService = serviceRecordService;
    }

    [HttpGet("by-motorcycle/{motorcycleId}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<ServiceRecordDto>>>> GetByMotorcycleId(Guid motorcycleId)
    {
        var serviceRecords = await _serviceRecordService.GetByMotorcycleIdAsync(motorcycleId);
        return Ok(ApiResponse<IEnumerable<ServiceRecordDto>>.CreateSuccess(serviceRecords));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<ServiceRecordDto>>> Create(CreateServiceRecordRequest request)
    {
        var serviceRecord = await _serviceRecordService.CreateAsync(request);
        return CreatedAtAction(nameof(GetByMotorcycleId), new { motorcycleId = serviceRecord.MotorcycleId }, ApiResponse<ServiceRecordDto>.CreateSuccess(serviceRecord));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<ServiceRecordDto>>> Update(Guid id, UpdateServiceRecordRequest request)
    {
        var serviceRecord = await _serviceRecordService.UpdateAsync(id, request);

        if (serviceRecord == null)
            return NotFound(ApiResponse<ServiceRecordDto>.CreateFailure("Service record not found."));

        return Ok(ApiResponse<ServiceRecordDto>.CreateSuccess(serviceRecord));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<object>>> Delete(Guid id)
    {
        var result = await _serviceRecordService.DeleteAsync(id);

        if (!result)
            return NotFound(ApiResponse<object>.CreateFailure("Service record not found."));

        return Ok(ApiResponse<object>.CreateSuccess(null, "Service record deleted successfully."));
    }
}
