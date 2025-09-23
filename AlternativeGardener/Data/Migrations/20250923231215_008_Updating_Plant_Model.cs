using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeGardener.Data.Migrations
{
    /// <inheritdoc />
    public partial class _008_Updating_Plant_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Plants",
                newName: "PlantDescription");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantType",
                table: "Plants",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PlantType",
                table: "Plants");

            migrationBuilder.RenameColumn(
                name: "PlantDescription",
                table: "Plants",
                newName: "Notes");
        }
    }
}
