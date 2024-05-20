using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonorReceiver.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddReceiversCitiesModelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Receivers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReceiversCities",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiversGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CitysId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiversCities", x => x.Guid);
                    table.ForeignKey(
                        name: "CitysId",
                        column: x => x.CitysId,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ReceiversGuid",
                        column: x => x.ReceiversGuid,
                        principalTable: "Receivers",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiversCities_CitysId",
                table: "ReceiversCities",
                column: "CitysId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiversCities_ReceiversGuid",
                table: "ReceiversCities",
                column: "ReceiversGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CitysId",
                table: "DonorsCities");

            migrationBuilder.DropTable(
                name: "ReceiversCities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Receivers");
        }
    }
}
