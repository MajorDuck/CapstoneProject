using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneProject.Data.Migrations
{
    public partial class test_documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ThirdParty",
                table: "Document",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentStatusID",
                table: "Document",
                column: "DocumentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentTypeID",
                table: "Document",
                column: "DocumentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Document_LlcID",
                table: "Document",
                column: "LlcID");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_DocumentStatus_DocumentStatusID",
                table: "Document",
                column: "DocumentStatusID",
                principalTable: "DocumentStatus",
                principalColumn: "DocumentStatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_DocumentType_DocumentTypeID",
                table: "Document",
                column: "DocumentTypeID",
                principalTable: "DocumentType",
                principalColumn: "DocumentTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Llc_LlcID",
                table: "Document",
                column: "LlcID",
                principalTable: "Llc",
                principalColumn: "LlcID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_DocumentStatus_DocumentStatusID",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_DocumentType_DocumentTypeID",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Llc_LlcID",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_DocumentStatusID",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_DocumentTypeID",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_LlcID",
                table: "Document");

            migrationBuilder.AlterColumn<string>(
                name: "ThirdParty",
                table: "Document",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
