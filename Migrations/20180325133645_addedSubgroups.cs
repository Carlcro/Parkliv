using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace reactslingshotproject.Migrations
{
    public partial class addedSubgroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Subgroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Subgroupid",
                table: "Members",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subgroups_AdminId",
                table: "Subgroups",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Subgroupid",
                table: "Members",
                column: "Subgroupid");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Subgroups_Subgroupid",
                table: "Members",
                column: "Subgroupid",
                principalTable: "Subgroups",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subgroups_Members_AdminId",
                table: "Subgroups",
                column: "AdminId",
                principalTable: "Members",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Subgroups_Subgroupid",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Subgroups_Members_AdminId",
                table: "Subgroups");

            migrationBuilder.DropIndex(
                name: "IX_Subgroups_AdminId",
                table: "Subgroups");

            migrationBuilder.DropIndex(
                name: "IX_Members_Subgroupid",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Subgroups");

            migrationBuilder.DropColumn(
                name: "Subgroupid",
                table: "Members");
        }
    }
}
