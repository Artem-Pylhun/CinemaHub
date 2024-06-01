using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaHub.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddingAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cb7027f9-70fc-4d9c-8c5c-1b9afba424fd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ce207111-fbea-48f0-8f12-68c7ea1b79ab"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ea757cbe-c94e-40a1-b7bf-f147d76eb509"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("09bbb539-5573-4d75-b0b1-7f1f7c4078eb"), new Guid("7250b7c4-99fe-43e5-b773-4178caa22904") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("09bbb539-5573-4d75-b0b1-7f1f7c4078eb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7250b7c4-99fe-43e5-b773-4178caa22904"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("cb7027f9-70fc-4d9c-8c5c-1b9afba424fd"), "cb7027f9-70fc-4d9c-8c5c-1b9afba424fd", "User", "USER" },
                    { new Guid("ce207111-fbea-48f0-8f12-68c7ea1b79ab"), "ce207111-fbea-48f0-8f12-68c7ea1b79ab", "Admin", "ADMIN" }
                });
        }
    }
}
