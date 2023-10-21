using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;

namespace OrderManager.Infrastructure.EntityConfigurations;

public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder
            .HasKey(oi => oi.Id);

        builder
            .Property(oi => oi.Id)
            .HasConversion
            (
                id => id.Value,
                value => new OrderItemId(value)
            );

        builder
            .Property(oi => oi.ProductId)
            .HasConversion
            (
                id => id.Value,
                value => new ProductId(value)
            );

        builder
            .HasOne<Order>()
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId)
            .IsRequired();
    }
}
