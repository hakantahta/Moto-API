using Microsoft.AspNetCore.Mvc;
using MotoService.Application.Common;
using MotoService.Application.Motorcycles.DTOs;
using MotoService.Application.Motorcycles.Interfaces;

namespace MotoService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MotorcyclesController : ControllerBase
{
    private readonly IMotorcycleService _motorcycleService;

    public MotorcyclesController(IMotorcycleService motorcycleService)
    {
        _motorcycleService = motorcycleService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<MotorcycleDto>>>> GetAll()
    {
        var motorcycles = await _motorcycleService.GetAllAsync();
        return Ok(ApiResponse<IEnumerable<MotorcycleDto>>.CreateSuccess(motorcycles));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<MotorcycleDto>>> GetById(Guid id)
    {
        var motorcycle = await _motorcycleService.GetByIdAsync(id);

        if (motorcycle == null)
            return NotFound(ApiResponse<MotorcycleDto>.CreateFailure("Motorcycle not found."));

        return Ok(ApiResponse<MotorcycleDto>.CreateSuccess(motorcycle));
    }

    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<MotorcycleDto>>>> GetByCustomerId(Guid customerId)
    {
        var motorcycles = await _motorcycleService.GetByCustomerIdAsync(customerId);
        return Ok(ApiResponse<IEnumerable<MotorcycleDto>>.CreateSuccess(motorcycles));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<MotorcycleDto>>> Create(CreateMotorcycleRequest request)
    {
        var motorcycle = await _motorcycleService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = motorcycle.Id }, ApiResponse<MotorcycleDto>.CreateSuccess(motorcycle));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<MotorcycleDto>>> Update(Guid id, UpdateMotorcycleRequest request)
    {
        var motorcycle = await _motorcycleService.UpdateAsync(id, request);

        if (motorcycle == null)
            return NotFound(ApiResponse<MotorcycleDto>.CreateFailure("Motorcycle not found."));

        return Ok(ApiResponse<MotorcycleDto>.CreateSuccess(motorcycle));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<object>>> Delete(Guid id)
    {
        var result = await _motorcycleService.DeleteAsync(id);

        if (!result)
            return NotFound(ApiResponse<object>.CreateFailure("Motorcycle not found."));

        return Ok(ApiResponse<object>.CreateSuccess(null, "Motorcycle deleted successfully."));
    }
}
