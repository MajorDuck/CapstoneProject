using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneProject.Data.Migrations
{
    public partial class updateDocumentSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CniPosRequestorUserID",
                table: "Document",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "CniPosRequestorUserID",
                table: "Document",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
