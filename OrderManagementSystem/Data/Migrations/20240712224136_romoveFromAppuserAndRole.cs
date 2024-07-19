using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class romoveFromAppuserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_CreatorId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_ModificationRolesId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CreatorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreatorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_CreatorId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_ModificationRolesId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModificationTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModificationRolesId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModificationTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Roles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationTime",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificationRolesId",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationTime",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatorId",
                table: "Users",
                column: "CreatorId",
                unique: true,
                filter: "[CreatorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatorId",
                table: "Roles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ModificationRolesId",
                table: "Roles",
                column: "ModificationRolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreatorId",
                table: "Roles",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_ModificationRolesId",
                table: "Roles",
                column: "ModificationRolesId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreatorId",
                table: "Users",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
