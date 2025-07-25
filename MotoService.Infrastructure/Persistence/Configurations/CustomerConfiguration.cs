namespace MotoService.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoService.Domain.Entities;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Phone)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);

        // Relationships
        builder.HasMany<Motorcycle>()
            .WithOne(m => m.Customer)
            .HasForeignKey(m => m.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}