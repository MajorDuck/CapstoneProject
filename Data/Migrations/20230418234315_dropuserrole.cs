using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneProject.Data.Migrations
{
    public partial class dropuserrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserLlc",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserLlc_LlcId",
                table: "UserLlc",
                column: "LlcId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLlc_UserId",
                table: "UserLlc",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLlc_AspNetUsers_UserId",
                table: "UserLlc",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLlc_Llc_LlcId",
                table: "UserLlc",
                column: "LlcId",
                principalTable: "Llc",
                principalColumn: "LlcID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLlc_AspNetUsers_UserId",
                table: "UserLlc");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLlc_Llc_LlcId",
                table: "UserLlc");

            migrationBuilder.DropIndex(
                name: "IX_UserLlc_LlcId",
                table: "UserLlc");

            migrationBuilder.DropIndex(
                name: "IX_UserLlc_UserId",
                table: "UserLlc");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserLlc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsEtcEtc = table.Column<bool>(type: "bit", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });
        }
    }
}
