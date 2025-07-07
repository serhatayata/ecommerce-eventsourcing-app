using Inventory.Domain.Models.Equipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Persistence.EntityConfigurations;

public class EquipmentImageEntityConfiguration : IEntityTypeConfiguration<EquipmentImage>
{
    public void Configure(EntityTypeBuilder<EquipmentImage> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Url).IsRequired().HasMaxLength(500);
    }
}
