using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaySky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVacancy_Users_UserId",
                table: "UserVacancy");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVacancy_Vacancies_VacanyId",
                table: "UserVacancy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVacancy",
                table: "UserVacancy");

            migrationBuilder.RenameTable(
                name: "UserVacancy",
                newName: "UserVacancies");

            migrationBuilder.RenameIndex(
                name: "IX_UserVacancy_UserId",
                table: "UserVacancies",
                newName: "IX_UserVacancies_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVacancies",
                table: "UserVacancies",
                columns: new[] { "VacanyId", "UserId" });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2023, 12, 21, 17, 53, 26, 718, DateTimeKind.Local).AddTicks(3898), new DateTime(2023, 12, 21, 17, 53, 26, 718, DateTimeKind.Local).AddTicks(3883) });

            migrationBuilder.AddForeignKey(
                name: "FK_UserVacancies_Users_UserId",
                table: "UserVacancies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVacancies_Vacancies_VacanyId",
                table: "UserVacancies",
                column: "VacanyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVacancies_Users_UserId",
                table: "UserVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVacancies_Vacancies_VacanyId",
                table: "UserVacancies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVacancies",
                table: "UserVacancies");

            migrationBuilder.RenameTable(
                name: "UserVacancies",
                newName: "UserVacancy");

            migrationBuilder.RenameIndex(
                name: "IX_UserVacancies_UserId",
                table: "UserVacancy",
                newName: "IX_UserVacancy_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVacancy",
                table: "UserVacancy",
                columns: new[] { "VacanyId", "UserId" });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpiryDate" },
                values: new object[] { new DateTime(2023, 12, 21, 17, 21, 55, 266, DateTimeKind.Local).AddTicks(5733), new DateTime(2023, 12, 21, 17, 21, 55, 266, DateTimeKind.Local).AddTicks(5713) });

            migrationBuilder.AddForeignKey(
                name: "FK_UserVacancy_Users_UserId",
                table: "UserVacancy",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVacancy_Vacancies_VacanyId",
                table: "UserVacancy",
                column: "VacanyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
