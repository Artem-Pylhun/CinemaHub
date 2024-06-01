using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaHub.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddScreenSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScreenSize",
                table: "Halls");

            migrationBuilder.AddColumn<Guid>(
                name: "ScreenSizeId",
                table: "Halls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ScreenSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenSize", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Halls_ScreenSizeId",
                table: "Halls",
                column: "ScreenSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_ScreenSize_ScreenSizeId",
                table: "Halls",
                column: "ScreenSizeId",
                principalTable: "ScreenSize",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_ScreenSize_ScreenSizeId",
                table: "Halls");

            migrationBuilder.DropTable(
                name: "ScreenSize");

            migrationBuilder.DropIndex(
                name: "IX_Halls_ScreenSizeId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "ScreenSizeId",
                table: "Halls");

            migrationBuilder.AddColumn<string>(
                name: "ScreenSize",
                table: "Halls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
