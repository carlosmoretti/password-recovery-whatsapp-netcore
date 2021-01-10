using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class alteracaoCampoChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UPR_BL_CHANGED",
                table: "USER_PASSWORD_REGISTRY",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UPR_BL_CHANGED",
                table: "USER_PASSWORD_REGISTRY");
        }
    }
}
