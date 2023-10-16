using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain.Entities;
using OrderManager.Domain.Identifiers;

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
            .HasOne<Order>()
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId)
            .IsRequired();
    }
}
