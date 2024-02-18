using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlxShop.Migrations
{
    /// <inheritdoc />
    public partial class addconectionsProductUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Registerdate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "07e54d3c-7ce2-43f0-8a19-70447ec2e478", 0, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Local), "1c497215-72bb-4305-9bbc-95685f2c52f7", "default@gmail.com", false, false, null, null, null, null, "+380980334755", false, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Local), "042afd20-aa8d-4a87-a789-4f19ef53be63", false, "default@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "07e54d3c-7ce2-43f0-8a19-70447ec2e478");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "07e54d3c-7ce2-43f0-8a19-70447ec2e478");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "07e54d3c-7ce2-43f0-8a19-70447ec2e478");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: "07e54d3c-7ce2-43f0-8a19-70447ec2e478");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: "07e54d3c-7ce2-43f0-8a19-70447ec2e478");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: "07e54d3c-7ce2-43f0-8a19-70447ec2e478");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "07e54d3c-7ce2-43f0-8a19-70447ec2e478");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");
        }
    }
}
