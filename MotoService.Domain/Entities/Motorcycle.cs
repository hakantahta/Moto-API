namespace MotoService.Domain.Entities;

using MotoService.Domain.Common;
using MotoService.Domain.Enums;

public class Motorcycle : BaseEntity
{
    public Guid CustomerId { get; set; }
    public MotorcycleBrand Brand { get; set; }
    public string Model { get; set; } = string.Empty;
    public string PlateNumber { get; set; } = string.Empty;
    public int Year { get; set; }
    
    // Navigation property
    public Customer? Customer { get; set; }
}