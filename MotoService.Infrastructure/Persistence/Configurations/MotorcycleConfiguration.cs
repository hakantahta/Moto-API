namespace MotoService.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoService.Domain.Entities;

public class MotorcycleConfiguration : IEntityTypeConfiguration<Motorcycle>
{
    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Model)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.PlateNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(m => m.Year)
            .IsRequired();

        // Relationships
        builder.HasOne(m => m.Customer)
            .WithMany()
            .HasForeignKey(m => m.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany<ServiceRecord>()
            .WithOne(sr => sr.Motorcycle)
            .HasForeignKey(sr => sr.MotorcycleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}