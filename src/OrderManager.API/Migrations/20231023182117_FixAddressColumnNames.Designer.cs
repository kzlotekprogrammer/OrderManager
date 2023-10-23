﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OrderManager.Infrastructure;

#nullable disable

namespace OrderManager.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231023182117_FixAddressColumnNames")]
    partial class FixAddressColumnNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OrderManager.Core.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.HasKey("Id")
                        .HasName("pk_customers");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("OrderManager.Core.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_orders_customer_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("OrderManager.Core.Domain.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("product_name");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_order_items");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_items_order_id");

                    b.ToTable("order_items", (string)null);
                });

            modelBuilder.Entity("OrderManager.Core.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uuid")
                        .HasColumnName("warehouse_id");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.HasIndex("WarehouseId")
                        .HasDatabaseName("ix_products_warehouse_id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("OrderManager.Core.Domain.Entities.Warehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.HasKey("Id")
                        .HasName("pk_warehouses");

                    b.ToTable("warehouses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d6fe83ac-d02b-42a7-a5e2-1d8bbe9f6f35")
                        });
                });

            modelBuilder.Entity("OrderManager.Core.Domain.Entities.Customer", b =>
                {
                    b.OwnsOne("OrderManager.Core.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_city");

                            b1.Property<string>("PostOffice")
                                .HasColumnType("text")
                                .HasColumnName("address_post_office");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("text")
                                .HasColumnName("address_postal_code");

                            b1.Property<string>("Street")
                                .HasColumnType("text")
                                .HasColumnName("address_street");

                            b1.HasKey("CustomerId");

                            b1.ToTable("customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId")
                                .HasConstraintName("fk_customers_customers_id");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("OrderManager.Core.Domain.Entities.Order", b =>
                {
                    b.HasOne("OrderManager.Core.Domain.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_customers_customer_id1");

                    b.OwnsOne("OrderManager.Core.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_city");

                            b1.Property<string>("PostOffice")
                                .HasColumnType("text")
                                .HasColumnName("address_post_office");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("text")
                                .HasColumnName("address_postal_code");

                            b1.Property<string>("Street")
                                .HasColumnType("text")
                                .HasColumnName("address_street");

                            b1.HasKey("OrderId");

                            b1.ToTable("orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId")
                                .HasConstraintName("fk_orders_orders_id");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("OrderManager.Core.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("OrderManager.Core.Domain.Entities.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_items_orders_order_temp_id");
                });

            modelBuilder.Entity("OrderManager.Core.Domain.Entities.Product", b =>
                {
                    b.HasOne("OrderManager.Core.Domain.Entities.Warehouse", null)
                        .WithMany("Products")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_warehouses_warehouse_temp_id");
                });

            modelBuilder.Entity("OrderManager.Core.Domain.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OrderManager.Core.Domain.Entities.Warehouse", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
