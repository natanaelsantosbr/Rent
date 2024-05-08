using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FailedEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f3219b39-ee18-40dc-9e53-5fe2b19400b7"));

            migrationBuilder.AlterColumn<string>(
                name: "CNHImagePath",
                table: "DeliveryMen",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d146dfe8-b61b-4d82-944f-4f9b5125ef60",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77dd47da-f840-46a1-9751-bc9d75903f65", new DateTime(2024, 5, 7, 23, 45, 41, 721, DateTimeKind.Local).AddTicks(1271), "AQAAAAIAAYagAAAAEHEKqdF2Kss+i9KBgkPvkAM2PM5SS0oCAAKxpt3gLb124/kHtGbo5P03NkqaOfZVQg==", "02a0f4cc-b69f-44b6-9d66-cc2125c8a52d" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeliveryManId", "Email", "IsAdmin", "IsDeliveryMan", "Name", "UserExternalId" },
                values: new object[] { new Guid("399e2245-03b7-4fcd-b258-1c52c830fa02"), new DateTime(2024, 5, 7, 23, 45, 41, 758, DateTimeKind.Local).AddTicks(3598), null, "admin@gmail.com", true, false, "Admin", new Guid("d146dfe8-b61b-4d82-944f-4f9b5125ef60") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("399e2245-03b7-4fcd-b258-1c52c830fa02"));

            migrationBuilder.AlterColumn<string>(
                name: "CNHImagePath",
                table: "DeliveryMen",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d146dfe8-b61b-4d82-944f-4f9b5125ef60",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3d29112-0fc6-4746-b8e7-7ad27e386317", new DateTime(2024, 5, 7, 22, 53, 14, 813, DateTimeKind.Local).AddTicks(3019), "AQAAAAIAAYagAAAAEBg+8GXtsOx+f/Op7mQcS8+ahReyk9FhihKpTLIuyNDH1zVa9Bw3dgg0PgjCg7XoEA==", "7f71ffbb-1c5f-4b66-b89a-d870134f0c26" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeliveryManId", "Email", "IsAdmin", "IsDeliveryMan", "Name", "UserExternalId" },
                values: new object[] { new Guid("f3219b39-ee18-40dc-9e53-5fe2b19400b7"), new DateTime(2024, 5, 7, 22, 53, 14, 852, DateTimeKind.Local).AddTicks(47), null, "admin@gmail.com", true, false, "Admin", new Guid("d146dfe8-b61b-4d82-944f-4f9b5125ef60") });
        }
    }
}
