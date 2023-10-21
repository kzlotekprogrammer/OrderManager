using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;

namespace OrderManager.Infrastructure.EntityConfigurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasConversion
            (
                id => id.Value,
                value => new ProductId(value)
            );

        builder
            .HasOne<Warehouse>()
            .WithMany(w => w.Products)
            .HasForeignKey(p => p.WarehouseId)
            .IsRequired();
    }
}