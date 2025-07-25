namespace MotoService.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MotoService.Application.Motorcycles.DTOs;
using MotoService.Application.Motorcycles.Interfaces;

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
    public async Task<ActionResult<IEnumerable<MotorcycleDto>>> GetAll()
    {
        var motorcycles = await _motorcycleService.GetAllAsync();
        return Ok(motorcycles);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MotorcycleDto>> GetById(Guid id)
    {
        var motorcycle = await _motorcycleService.GetByIdAsync(id);
        
        if (motorcycle == null)
            return NotFound();
            
        return Ok(motorcycle);
    }

    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<IEnumerable<MotorcycleDto>>> GetByCustomerId(Guid customerId)
    {
        var motorcycles = await _motorcycleService.GetByCustomerIdAsync(customerId);
        return Ok(motorcycles);
    }

    [HttpPost]
    public async Task<ActionResult<MotorcycleDto>> Create(CreateMotorcycleRequest request)
    {
        var motorcycle = await _motorcycleService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = motorcycle.Id }, motorcycle);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MotorcycleDto>> Update(Guid id, UpdateMotorcycleRequest request)
    {
        var motorcycle = await _motorcycleService.UpdateAsync(id, request);
        
        if (motorcycle == null)
            return NotFound();
            
        return Ok(motorcycle);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _motorcycleService.DeleteAsync(id);
        
        if (!result)
            return NotFound();
            
        return NoContent();
    }
}