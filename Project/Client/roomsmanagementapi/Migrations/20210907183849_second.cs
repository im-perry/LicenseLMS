using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace roomsmanagementapi.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Types_TypeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_TypeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Rooms");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Types",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Types_RoomId",
                table: "Types",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Rooms_RoomId",
                table: "Types",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Types_Rooms_RoomId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Types_RoomId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Types");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_TypeId",
                table: "Rooms",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Types_TypeId",
                table: "Rooms",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
