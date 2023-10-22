using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaySky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeExpireDateToDatetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "CreatedDate", "Description", "ExpiryDate", "Title" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description", new DateTime(2023, 12, 19, 1, 46, 4, 70, DateTimeKind.Local).AddTicks(2479), "First Vacancy" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "ExpiryDate",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
