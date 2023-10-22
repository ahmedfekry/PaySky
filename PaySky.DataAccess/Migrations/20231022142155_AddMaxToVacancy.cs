using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaySky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMaxToVacancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxNumberOfApplicants",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate", "MaxNumberOfApplicants" },
                values: new object[] { new DateTime(2023, 12, 21, 17, 21, 55, 266, DateTimeKind.Local).AddTicks(5733), new DateTime(2023, 12, 21, 17, 21, 55, 266, DateTimeKind.Local).AddTicks(5713), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxNumberOfApplicants",
                table: "Vacancies");

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2023, 12, 21, 17, 7, 57, 779, DateTimeKind.Local).AddTicks(6726), new DateTime(2023, 12, 21, 17, 7, 57, 779, DateTimeKind.Local).AddTicks(6711) });
        }
    }
}
