using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneProject.Data.Migrations
{
    public partial class dropuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_AspNetUsers_UserId",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_UserId",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Document");

            migrationBuilder.AlterColumn<string>(
                name: "CniPosRequestorUserID",
                table: "Document",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Document_CniPosRequestorUserID",
                table: "Document",
                column: "CniPosRequestorUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_AspNetUsers_CniPosRequestorUserID",
                table: "Document",
                column: "CniPosRequestorUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_AspNetUsers_CniPosRequestorUserID",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_CniPosRequestorUserID",
                table: "Document");

            migrationBuilder.AlterColumn<string>(
                name: "CniPosRequestorUserID",
                table: "Document",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Document",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Document_UserId",
                table: "Document",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_AspNetUsers_UserId",
                table: "Document",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
