using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeGardener.Data.Migrations
{
    /// <inheritdoc />
    public partial class _002_Add_Gardens_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    GardenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GardenName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GardenLocation = table.Column<int>(type: "int", nullable: true),
                    GardenSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GardenType = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.GardenID);
                    table.ForeignKey(
                        name: "FK_Gardens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_UserId",
                table: "Gardens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gardens");
        }
    }
}
