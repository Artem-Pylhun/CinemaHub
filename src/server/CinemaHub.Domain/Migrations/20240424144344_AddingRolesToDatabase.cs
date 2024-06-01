using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaHub.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddingRolesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("cb7027f9-70fc-4d9c-8c5c-1b9afba424fd"), "cb7027f9-70fc-4d9c-8c5c-1b9afba424fd", "User", "USER" },
                    { new Guid("ce207111-fbea-48f0-8f12-68c7ea1b79ab"), "ce207111-fbea-48f0-8f12-68c7ea1b79ab", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cb7027f9-70fc-4d9c-8c5c-1b9afba424fd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ce207111-fbea-48f0-8f12-68c7ea1b79ab"));
        }
    }
}
