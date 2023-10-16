using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Core.Domain.Entities;
using OrderManager.Core.Domain.ValueObjects;
using OrderManager.Domain.Identifiers;

namespace OrderManager.Infrastructure.EntityConfigurations;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasConversion
            (
                id => id.Value,
                value => new CustomerId(value)
            );

        builder.OwnsOne(c => c.Address);
    }
}
