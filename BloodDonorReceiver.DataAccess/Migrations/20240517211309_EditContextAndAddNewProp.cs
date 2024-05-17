using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonorReceiver.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditContextAndAddNewProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Users_Guid",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Receivers_Users_Guid",
                table: "Receivers");

            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "Receivers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "TCNO",
                table: "Donors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "Donors",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Receivers_UserGuid",
                table: "Receivers",
                column: "UserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_UserGuid",
                table: "Donors",
                column: "UserGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Users_UserGuid",
                table: "Donors",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receivers_Users_UserGuid",
                table: "Receivers",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Users_UserGuid",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Receivers_Users_UserGuid",
                table: "Receivers");

            migrationBuilder.DropIndex(
                name: "IX_Receivers_UserGuid",
                table: "Receivers");

            migrationBuilder.DropIndex(
                name: "IX_Donors_UserGuid",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Receivers");

            migrationBuilder.DropColumn(
                name: "TCNO",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Donors");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Users_Guid",
                table: "Donors",
                column: "Guid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receivers_Users_Guid",
                table: "Receivers",
                column: "Guid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
