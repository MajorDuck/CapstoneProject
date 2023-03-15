using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneProject.Data.Migrations
{
    public partial class documentsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeID = table.Column<int>(type: "int", nullable: false),
                    LlcID = table.Column<int>(type: "int", nullable: false),
                    CniPosRequestorUserID = table.Column<int>(type: "int", nullable: false),
                    CniContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdParty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    DocumentStatusID = table.Column<int>(type: "int", nullable: false),
                    DraftedByUserID = table.Column<int>(type: "int", nullable: false),
                    DateLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LinkToDocument = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");
        }
    }
}
