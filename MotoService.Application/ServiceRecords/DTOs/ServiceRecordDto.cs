namespace MotoService.Application.ServiceRecords.DTOs;

public class ServiceRecordDto
{
    public Guid Id { get; set; }
    public Guid MotorcycleId { get; set; }
    public string MotorcycleInfo { get; set; } = string.Empty; // Marka, Model, Plaka
    public DateTime ServiceDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal TotalCost { get; set; }
    public DateTime? NextServiceDate { get; set; }
    public DateTime CreatedAt { get; set; }
}