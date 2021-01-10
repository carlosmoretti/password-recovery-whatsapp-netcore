using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER_PASSWORD_REGISTRY",
                columns: table => new
                {
                    UPR_CD_ID = table.Column<Guid>(nullable: false),
                    USER_CD_ID = table.Column<Guid>(nullable: false),
                    UPR_TX_PASSWORD = table.Column<string>(nullable: true),
                    UPR_DT_DATA = table.Column<DateTime>(nullable: false),
                    UPR_TX_TOKEN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PASSWORD_REGISTRY", x => x.UPR_CD_ID);
                    table.ForeignKey(
                        name: "FK_USER_PASSWORD_REGISTRY_USER_USER_CD_ID",
                        column: x => x.USER_CD_ID,
                        principalTable: "USER",
                        principalColumn: "USER_CD_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USER_PASSWORD_REGISTRY_USER_CD_ID",
                table: "USER_PASSWORD_REGISTRY",
                column: "USER_CD_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER_PASSWORD_REGISTRY");
        }
    }
}
