namespace MotoService.Application.Motorcycles.DTOs;

using MotoService.Domain.Enums;

public class CreateMotorcycleRequest
{
    public Guid CustomerId { get; set; }
    public MotorcycleBrand Brand { get; set; }
    public string Model { get; set; } = string.Empty;
    public string PlateNumber { get; set; } = string.Empty;
    public int Year { get; set; }
}