using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaHub.Domain.Migrations
{
    /// <inheritdoc />
    public partial class MovieMinAgeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinAge",
                table: "Movies",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinAge",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("09bbb539-5573-4d75-b0b1-7f1f7c4078eb"), "09bbb539-5573-4d75-b0b1-7f1f7c4078eb", "Admin", "ADMIN" },
                    { new Guid("ea757cbe-c94e-40a1-b7bf-f147d76eb509"), "ea757cbe-c94e-40a1-b7bf-f147d76eb509", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7250b7c4-99fe-43e5-b773-4178caa22904"), 0, "b07a974d-ae09-4838-a95a-07b07c12f803", new DateTime(2024, 4, 24, 18, 22, 15, 791, DateTimeKind.Local).AddTicks(9795), "admin@gmail.com", true, "Артем", "Пильгун", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEGQei0OJRfWc4igTuy2rpaNczCIZVMsNFNarfiPROvdVm8lvSa0iMKgUCiRdu6z5ug==", null, false, "6d5d2cde-e90c-414a-a0b0-d6d8da25a4e0", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("09bbb539-5573-4d75-b0b1-7f1f7c4078eb"), new Guid("7250b7c4-99fe-43e5-b773-4178caa22904") });
        }
    }
}
