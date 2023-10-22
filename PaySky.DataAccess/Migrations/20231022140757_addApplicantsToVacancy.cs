using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaySky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addApplicantsToVacancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserVacancy",
                columns: table => new
                {
                    VacanyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVacancy", x => new { x.VacanyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserVacancy_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVacancy_Vacancies_VacanyId",
                        column: x => x.VacanyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2023, 12, 21, 17, 7, 57, 779, DateTimeKind.Local).AddTicks(6726), new DateTime(2023, 12, 21, 17, 7, 57, 779, DateTimeKind.Local).AddTicks(6711) });

            migrationBuilder.CreateIndex(
                name: "IX_UserVacancy_UserId",
                table: "UserVacancy",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVacancy");

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2023, 12, 20, 0, 54, 56, 488, DateTimeKind.Local).AddTicks(5609), new DateTime(2023, 12, 20, 0, 54, 56, 488, DateTimeKind.Local).AddTicks(5591) });
        }
    }
}
