using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonorReceiver.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateBloodCenterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "UserGuid",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "UserGuid",
                table: "Receivers");

            migrationBuilder.CreateTable(
                name: "BloodCenters",
                columns: table => new
                {
                    TeamId = table.Column<string>(type: "text", nullable: false),
                    TeamName = table.Column<string>(type: "text", nullable: false),
                    BloodDonationCenterName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodCenters", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_BloodCenters_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BloodCenters_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodCenters_CityId",
                table: "BloodCenters",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodCenters_StateId",
                table: "BloodCenters",
                column: "StateId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Users_Guid",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Receivers_Users_Guid",
                table: "Receivers");

            migrationBuilder.DropTable(
                name: "BloodCenters");

            migrationBuilder.AddForeignKey(
                name: "UserGuid",
                table: "Donors",
                column: "Guid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "UserGuid",
                table: "Receivers",
                column: "Guid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
