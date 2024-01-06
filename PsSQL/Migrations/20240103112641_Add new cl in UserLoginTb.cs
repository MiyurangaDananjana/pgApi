using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsSQL.Migrations
{
    public partial class AddnewclinUserLoginTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserStatus",
                table: "UserLogin",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "UserLogin");
        }
    }
}
