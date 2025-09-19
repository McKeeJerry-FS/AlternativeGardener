using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeGardener.Data.Migrations
{
    /// <inheritdoc />
    public partial class _004_Add_Plant_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePlanted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrowthStatus = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPerennial = table.Column<bool>(type: "bit", nullable: false),
                    LastWatered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastFertilized = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPruned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<int>(type: "int", nullable: true),
                    SunlightRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoilType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WateringSchedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FertilizingSchedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PruningSchedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PestControlNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiseaseControlNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GardenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plant_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plant_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "GardenID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plant_AppUserId",
                table: "Plant",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_GardenId",
                table: "Plant",
                column: "GardenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plant");
        }
    }
}
