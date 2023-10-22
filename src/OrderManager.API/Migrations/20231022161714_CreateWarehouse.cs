using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManager.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "warehouses",
                column: "id",
                value: new Guid("d6fe83ac-d02b-42a7-a5e2-1d8bbe9f6f35"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "warehouses",
                keyColumn: "id",
                keyValue: new Guid("d6fe83ac-d02b-42a7-a5e2-1d8bbe9f6f35"));
        }
    }
}
