using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManager.API.Migrations
{
    /// <inheritdoc />
    public partial class FixAddressColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address_postal_office",
                table: "orders",
                newName: "address_post_office");

            migrationBuilder.RenameColumn(
                name: "address_postal_office",
                table: "customers",
                newName: "address_post_office");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address_post_office",
                table: "orders",
                newName: "address_postal_office");

            migrationBuilder.RenameColumn(
                name: "address_post_office",
                table: "customers",
                newName: "address_postal_office");
        }
    }
}
