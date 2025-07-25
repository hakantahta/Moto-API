namespace MotoService.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoService.Domain.Entities;

public class ServiceRecordConfiguration : IEntityTypeConfiguration<ServiceRecord>
{
    public void Configure(EntityTypeBuilder<ServiceRecord> builder)
    {
        builder.HasKey(sr => sr.Id);

        builder.Property(sr => sr.ServiceDate)
            .IsRequired();

        builder.Property(sr => sr.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(sr => sr.TotalCost)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        // Relationships
        builder.HasOne(sr => sr.Motorcycle)
            .WithMany()
            .HasForeignKey(sr => sr.MotorcycleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}