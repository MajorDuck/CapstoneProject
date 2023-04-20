using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneProject.Data.Migrations
{
    public partial class updateUserLLCtoUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLlc_AspNetUsers_UserId",
                table: "UserLlc");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "UserLlc");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserLlc",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLlc_AspNetUsers_UserId",
                table: "UserLlc",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLlc_AspNetUsers_UserId",
                table: "UserLlc");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserLlc",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "UserLlc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLlc_AspNetUsers_UserId",
                table: "UserLlc",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
