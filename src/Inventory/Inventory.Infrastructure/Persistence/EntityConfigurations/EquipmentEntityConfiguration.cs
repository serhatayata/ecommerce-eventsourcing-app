using Inventory.Domain.Models.Equipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Persistence.EntityConfigurations;

public class EquipmentEntityConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.OwnerUserId).IsRequired();
        builder.OwnsOne(e => e.Details, details =>
        {
            details.Property(d => d.Name).IsRequired().HasMaxLength(200);
            details.Property(d => d.Description).HasMaxLength(1000);
        });
        builder.OwnsOne(e => e.PricePerDay, price =>
        {
            price.Property(p => p.Amount).IsRequired().HasColumnType("decimal(18,2)");
            price.Property(p => p.Currency).IsRequired().HasMaxLength(10);
        });
        builder.Property(e => e.IsAvailable).IsRequired();
        builder.HasMany(e => e.Images)
            .WithOne()
            .HasForeignKey("EquipmentId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
