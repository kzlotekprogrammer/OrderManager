﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.Identifiers;

namespace OrderManager.Infrastructure.EntityConfigurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasKey(o => o.Id);

        builder
            .Property(o => o.Id)
            .HasConversion
            (
                id => id.Value,
                value => new OrderId(value)
            );

        builder
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired();

        builder.OwnsOne(c => c.Address);
    }
}