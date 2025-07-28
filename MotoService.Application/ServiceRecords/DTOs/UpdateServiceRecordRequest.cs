namespace MotoService.Application.ServiceRecords.DTOs;

public class UpdateServiceRecordRequest
{
    public DateTime? ServiceDate { get; set; }
    public string? Description { get; set; }
    public decimal? TotalCost { get; set; }
    public DateTime? NextServiceDate { get; set; }
}