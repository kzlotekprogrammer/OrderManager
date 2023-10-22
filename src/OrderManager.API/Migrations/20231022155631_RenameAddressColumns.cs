using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManager.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameAddressColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address_zip_code",
                table: "orders",
                newName: "address_postal_office");

            migrationBuilder.RenameColumn(
                name: "address_state",
                table: "orders",
                newName: "address_postal_code");

            migrationBuilder.RenameColumn(
                name: "address_zip_code",
                table: "customers",
                newName: "address_postal_office");

            migrationBuilder.RenameColumn(
                name: "address_state",
                table: "customers",
                newName: "address_postal_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address_postal_office",
                table: "orders",
                newName: "address_zip_code");

            migrationBuilder.RenameColumn(
                name: "address_postal_code",
                table: "orders",
                newName: "address_state");

            migrationBuilder.RenameColumn(
                name: "address_postal_office",
                table: "customers",
                newName: "address_zip_code");

            migrationBuilder.RenameColumn(
                name: "address_postal_code",
                table: "customers",
                newName: "address_state");
        }
    }
}
