using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst.Migrations
{
    public partial class date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DateId",
                table: "Files",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SomeDate = table.Column<DateTime>(nullable: false),
                    FileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dates_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DatesFiles",
                columns: table => new
                {
                    DateId = table.Column<int>(nullable: false),
                    FileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatesFiles", x => new { x.DateId, x.FileId });
                    table.ForeignKey(
                        name: "FK_DatesFiles_Dates_DateId",
                        column: x => x.DateId,
                        principalTable: "Dates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatesFiles_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_DateId",
                table: "Files",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_Dates_FileId",
                table: "Dates",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_DatesFiles_FileId",
                table: "DatesFiles",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Dates_DateId",
                table: "Files",
                column: "DateId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Dates_DateId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "DatesFiles");

            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.DropIndex(
                name: "IX_Files_DateId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "Files");
        }
    }
}
