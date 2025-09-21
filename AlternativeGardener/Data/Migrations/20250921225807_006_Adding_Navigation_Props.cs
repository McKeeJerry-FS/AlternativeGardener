using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeGardener.Data.Migrations
{
    /// <inheritdoc />
    public partial class _006_Adding_Navigation_Props : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chemical_AspNetUsers_UserId",
                table: "Chemical");

            migrationBuilder.DropForeignKey(
                name: "FK_Chemical_Gardens_GardenId",
                table: "Chemical");

            migrationBuilder.DropForeignKey(
                name: "FK_Nutrient_AspNetUsers_UserId",
                table: "Nutrient");

            migrationBuilder.DropForeignKey(
                name: "FK_Nutrient_Gardens_GardenId",
                table: "Nutrient");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_AspNetUsers_AppUserId",
                table: "Plant");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Gardens_GardenId",
                table: "Plant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plant",
                table: "Plant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nutrient",
                table: "Nutrient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chemical",
                table: "Chemical");

            migrationBuilder.RenameTable(
                name: "Plant",
                newName: "Plants");

            migrationBuilder.RenameTable(
                name: "Nutrient",
                newName: "Nutrients");

            migrationBuilder.RenameTable(
                name: "Chemical",
                newName: "Chemicals");

            migrationBuilder.RenameIndex(
                name: "IX_Plant_GardenId",
                table: "Plants",
                newName: "IX_Plants_GardenId");

            migrationBuilder.RenameIndex(
                name: "IX_Plant_AppUserId",
                table: "Plants",
                newName: "IX_Plants_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Nutrient_UserId",
                table: "Nutrients",
                newName: "IX_Nutrients_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Nutrient_GardenId",
                table: "Nutrients",
                newName: "IX_Nutrients_GardenId");

            migrationBuilder.RenameIndex(
                name: "IX_Chemical_UserId",
                table: "Chemicals",
                newName: "IX_Chemicals_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Chemical_GardenId",
                table: "Chemicals",
                newName: "IX_Chemicals_GardenId");

            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "Plants",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plants",
                table: "Plants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nutrients",
                table: "Nutrients",
                column: "NutrientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chemicals",
                table: "Chemicals",
                column: "ChemicalId");

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GardenId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "GardenID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_RecordId",
                table: "Plants",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_GardenId",
                table: "Records",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserId",
                table: "Records",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chemicals_AspNetUsers_UserId",
                table: "Chemicals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chemicals_Gardens_GardenId",
                table: "Chemicals",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "GardenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrients_AspNetUsers_UserId",
                table: "Nutrients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrients_Gardens_GardenId",
                table: "Nutrients",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "GardenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_AspNetUsers_AppUserId",
                table: "Plants",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Gardens_GardenId",
                table: "Plants",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "GardenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Records_RecordId",
                table: "Plants",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "RecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chemicals_AspNetUsers_UserId",
                table: "Chemicals");

            migrationBuilder.DropForeignKey(
                name: "FK_Chemicals_Gardens_GardenId",
                table: "Chemicals");

            migrationBuilder.DropForeignKey(
                name: "FK_Nutrients_AspNetUsers_UserId",
                table: "Nutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_Nutrients_Gardens_GardenId",
                table: "Nutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AspNetUsers_AppUserId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Gardens_GardenId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Records_RecordId",
                table: "Plants");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plants",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_RecordId",
                table: "Plants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nutrients",
                table: "Nutrients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chemicals",
                table: "Chemicals");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Plants");

            migrationBuilder.RenameTable(
                name: "Plants",
                newName: "Plant");

            migrationBuilder.RenameTable(
                name: "Nutrients",
                newName: "Nutrient");

            migrationBuilder.RenameTable(
                name: "Chemicals",
                newName: "Chemical");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_GardenId",
                table: "Plant",
                newName: "IX_Plant_GardenId");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_AppUserId",
                table: "Plant",
                newName: "IX_Plant_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Nutrients_UserId",
                table: "Nutrient",
                newName: "IX_Nutrient_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Nutrients_GardenId",
                table: "Nutrient",
                newName: "IX_Nutrient_GardenId");

            migrationBuilder.RenameIndex(
                name: "IX_Chemicals_UserId",
                table: "Chemical",
                newName: "IX_Chemical_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Chemicals_GardenId",
                table: "Chemical",
                newName: "IX_Chemical_GardenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plant",
                table: "Plant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nutrient",
                table: "Nutrient",
                column: "NutrientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chemical",
                table: "Chemical",
                column: "ChemicalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chemical_AspNetUsers_UserId",
                table: "Chemical",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chemical_Gardens_GardenId",
                table: "Chemical",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "GardenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrient_AspNetUsers_UserId",
                table: "Nutrient",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrient_Gardens_GardenId",
                table: "Nutrient",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "GardenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_AspNetUsers_AppUserId",
                table: "Plant",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Gardens_GardenId",
                table: "Plant",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "GardenID");
        }
    }
}
