using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneProject.Data.Migrations
{
    public partial class userllcsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLlc",
                columns: table => new
                {
                    UserLlcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LlcId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLlc", x => x.UserLlcId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLlc");
        }
    }
}
