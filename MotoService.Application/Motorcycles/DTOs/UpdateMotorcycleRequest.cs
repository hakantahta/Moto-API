namespace MotoService.Application.Motorcycles.DTOs;

using MotoService.Domain.Enums;

public class UpdateMotorcycleRequest
{
    public Guid? CustomerId { get; set; }
    public MotorcycleBrand? Brand { get; set; }
    public string? Model { get; set; }
    public string? PlateNumber { get; set; }
    public int? Year { get; set; }
}