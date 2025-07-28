using Microsoft.AspNetCore.Mvc;
using MotoService.Application.Common;
using MotoService.Application.Customers.DTOs;
using MotoService.Application.Customers.Interfaces;

namespace MotoService.API.Controllers;

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
    public async Task<ActionResult<ApiResponse<IEnumerable<CustomerDto>>>> GetAll()
    {
        var customers = await _customerService.GetAllAsync();
        return Ok(ApiResponse<IEnumerable<CustomerDto>>.CreateSuccess(customers));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<CustomerDto>>> GetById(Guid id)
    {
        var customer = await _customerService.GetByIdAsync(id);

        if (customer == null)
            return NotFound(ApiResponse<CustomerDto>.CreateFailure("Customer not found."));

        return Ok(ApiResponse<CustomerDto>.CreateSuccess(customer));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<CustomerDto>>> Create(CreateCustomerRequest request)
    {
        var customer = await _customerService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = customer.Id }, ApiResponse<CustomerDto>.CreateSuccess(customer));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<CustomerDto>>> Update(Guid id, UpdateCustomerRequest request)
    {
        var customer = await _customerService.UpdateAsync(id, request);

        if (customer == null)
            return NotFound(ApiResponse<CustomerDto>.CreateFailure("Customer not found."));

        return Ok(ApiResponse<CustomerDto>.CreateSuccess(customer));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<object>>> Delete(Guid id)
    {
        var result = await _customerService.DeleteAsync(id);

        if (!result)
            return NotFound(ApiResponse<object>.CreateFailure("Customer not found."));

        return Ok(ApiResponse<object>.CreateSuccess(null, "Customer deleted successfully."));
    }
}
