using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSharing.DataAccessLayer.Migrations
{
    public partial class One : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Users_UserId",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "UserChatId",
                table: "Foods",
                newName: "ChatId");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Foods",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 16, 18, 44, 35, 23, DateTimeKind.Utc).AddTicks(7921), true });

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Users_UserId",
                table: "Foods",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Users_UserId",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Foods",
                newName: "UserChatId");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Foods",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "IsActive" },
                values: new object[] { new DateTime(2022, 4, 16, 18, 30, 37, 457, DateTimeKind.Utc).AddTicks(6021), false });

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Users_UserId",
                table: "Foods",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
