using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaySky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangePasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2023, 12, 20, 0, 25, 2, 21, DateTimeKind.Local).AddTicks(7320), new DateTime(2023, 12, 20, 0, 25, 2, 21, DateTimeKind.Local).AddTicks(7300) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2023, 12, 19, 23, 54, 30, 802, DateTimeKind.Local).AddTicks(6982), new DateTime(2023, 12, 19, 23, 54, 30, 802, DateTimeKind.Local).AddTicks(6968) });
        }
    }
}
