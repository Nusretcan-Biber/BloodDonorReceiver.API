using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonorReceiver.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndEditDonorsProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Receivers",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Gender",
                table: "Donors",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Donors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsCronicIllness",
                table: "Donors",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Receivers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "IsCronicIllness",
                table: "Donors");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Donors",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
