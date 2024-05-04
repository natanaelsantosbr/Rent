using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ColumnDateCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDoCadastro",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "DataDoCadastro",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DataDoCadastro",
                table: "Motorcycles",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DataDoCadastro",
                table: "MotorcycleRentals",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DataDoCadastro",
                table: "DeliveryMen",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "DataDoCadastro");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Motorcycles",
                newName: "DataDoCadastro");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "MotorcycleRentals",
                newName: "DataDoCadastro");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "DeliveryMen",
                newName: "DataDoCadastro");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDoCadastro",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
