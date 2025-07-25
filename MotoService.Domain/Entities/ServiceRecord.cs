namespace MotoService.Domain.Entities;

using MotoService.Domain.Common;

public class ServiceRecord : BaseEntity
{
    public Guid MotorcycleId { get; set; }
    public DateTime ServiceDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal TotalCost { get; set; }
    public DateTime? NextServiceDate { get; set; }
    
    // Navigation property
    public Motorcycle? Motorcycle { get; set; }
}