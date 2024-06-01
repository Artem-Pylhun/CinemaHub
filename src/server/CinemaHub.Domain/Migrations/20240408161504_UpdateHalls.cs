using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaHub.Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHalls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Cinemas_CinemaId",
                table: "Halls");

            migrationBuilder.AlterColumn<Guid>(
                name: "CinemaId",
                table: "Halls",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Cinemas_CinemaId",
                table: "Halls",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Cinemas_CinemaId",
                table: "Halls");

            migrationBuilder.AlterColumn<Guid>(
                name: "CinemaId",
                table: "Halls",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Cinemas_CinemaId",
                table: "Halls",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
