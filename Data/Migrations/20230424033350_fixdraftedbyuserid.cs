using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneProject.Data.Migrations
{
    public partial class fixdraftedbyuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DraftedByUserID",
                table: "Document",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DraftedByUserID",
                table: "Document",
                column: "DraftedByUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_AspNetUsers_DraftedByUserID",
                table: "Document",
                column: "DraftedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_AspNetUsers_DraftedByUserID",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_DraftedByUserID",
                table: "Document");

            migrationBuilder.AlterColumn<int>(
                name: "DraftedByUserID",
                table: "Document",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
