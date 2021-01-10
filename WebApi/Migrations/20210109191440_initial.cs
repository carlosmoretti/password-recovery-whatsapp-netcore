using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    USER_CD_ID = table.Column<Guid>(nullable: false),
                    USER_TX_USERNAME = table.Column<string>(nullable: true),
                    USER_TX_PASSWORD = table.Column<string>(nullable: true),
                    USER_NM_CELLPHONE = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    USER_TX_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.USER_CD_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
