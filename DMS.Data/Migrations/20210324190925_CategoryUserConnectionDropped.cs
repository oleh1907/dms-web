﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class CategoryUserConnectionDropped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UsersUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UsersUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UsersUserId",
                table: "Categories",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UsersUserId",
                table: "Categories",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
