namespace MotoService.Application.ServiceRecords.DTOs;

public class CreateServiceRecordRequest
{
    public Guid MotorcycleId { get; set; }
    public DateTime ServiceDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal TotalCost { get; set; }
    public DateTime? NextServiceDate { get; set; }
}