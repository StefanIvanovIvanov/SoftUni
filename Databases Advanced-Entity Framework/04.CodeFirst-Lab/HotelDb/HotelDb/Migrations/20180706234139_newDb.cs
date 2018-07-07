using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelDb.Migrations
{
    public partial class newDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardNumber = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BedCount = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    RoomNickname = table.Column<string>(nullable: true),
                    RoomType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomKeyCard",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false),
                    KeyCardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomKeyCard", x => new { x.RoomId, x.KeyCardId });
                    table.ForeignKey(
                        name: "FK_RoomKeyCard_KeyCards_KeyCardId",
                        column: x => x.KeyCardId,
                        principalTable: "KeyCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomKeyCard_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomKeyCard_KeyCardId",
                table: "RoomKeyCard",
                column: "KeyCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomKeyCard");

            migrationBuilder.DropTable(
                name: "KeyCards");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
