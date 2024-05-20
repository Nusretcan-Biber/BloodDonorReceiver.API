using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonorReceiver.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDonorsCitesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Donors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DonorsCities",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DonorsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CitysId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorsCities", x => x.Guid);
                    table.ForeignKey(
                        name: "CitysId",
                        column: x => x.CitysId,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "DonorsGuid",
                        column: x => x.DonorsGuid,
                        principalTable: "Donors",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonorsCities_CitysId",
                table: "DonorsCities",
                column: "CitysId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorsCities_DonorsGuid",
                table: "DonorsCities",
                column: "DonorsGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorsCities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Donors");
        }
    }
}
