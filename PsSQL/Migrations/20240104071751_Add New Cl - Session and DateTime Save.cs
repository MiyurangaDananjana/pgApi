using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsSQL.Migrations
{
    public partial class AddNewClSessionandDateTimeSave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SessionCreateDateTime",
                table: "UserLogin",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "UserLogin",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionCreateDateTime",
                table: "UserLogin");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "UserLogin");
        }
    }
}
