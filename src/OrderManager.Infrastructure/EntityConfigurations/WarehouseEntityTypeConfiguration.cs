using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;

namespace OrderManager.Infrastructure.EntityConfigurations;

public class WarehouseEntityTypeConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder
            .HasKey(w => w.Id);

        builder
            .Property(w => w.Id)
            .HasConversion
            (
                id => id.Value,
                value => new WarehouseId(value)
            );
    }
}