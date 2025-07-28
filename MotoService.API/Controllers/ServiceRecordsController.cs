namespace MotoService.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MotoService.Application.ServiceRecords.DTOs;
using MotoService.Application.ServiceRecords.Interfaces;

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
    public async Task<ActionResult<IEnumerable<ServiceRecordDto>>> GetByMotorcycleId(Guid motorcycleId)
    {
        var serviceRecords = await _serviceRecordService.GetByMotorcycleIdAsync(motorcycleId);
        return Ok(serviceRecords);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceRecordDto>> Create(CreateServiceRecordRequest request)
    {
        var serviceRecord = await _serviceRecordService.CreateAsync(request);
        return CreatedAtAction(nameof(GetByMotorcycleId), new { motorcycleId = serviceRecord.MotorcycleId }, serviceRecord);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceRecordDto>> Update(Guid id, UpdateServiceRecordRequest request)
    {
        var serviceRecord = await _serviceRecordService.UpdateAsync(id, request);
        
        if (serviceRecord == null)
            return NotFound();
            
        return Ok(serviceRecord);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _serviceRecordService.DeleteAsync(id);
        
        if (!result)
            return NotFound();
            
        return NoContent();
    }
}