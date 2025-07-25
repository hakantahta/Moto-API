namespace MotoService.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using MotoService.Application.Customers.DTOs;
using MotoService.Application.Customers.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
    {
        var customers = await _customerService.GetAllAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetById(Guid id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        
        if (customer == null)
            return NotFound();
            
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> Create(CreateCustomerRequest request)
    {
        var customer = await _customerService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerDto>> Update(Guid id, UpdateCustomerRequest request)
    {
        var customer = await _customerService.UpdateAsync(id, request);
        
        if (customer == null)
            return NotFound();
            
        return Ok(customer);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _customerService.DeleteAsync(id);
        
        if (!result)
            return NotFound();
            
        return NoContent();
    }
}