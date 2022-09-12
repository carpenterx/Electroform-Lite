using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroformLite.Infrastructure.Migrations
{
    public partial class AllRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserData",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DataGroupTemplateDataTemplate",
                columns: table => new
                {
                    DataGroupTemplatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataTemplatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataGroupTemplateDataTemplate", x => new { x.DataGroupTemplatesId, x.DataTemplatesId });
                    table.ForeignKey(
                        name: "FK_DataGroupTemplateDataTemplate_DataGroupTemplates_DataGroupTemplatesId",
                        column: x => x.DataGroupTemplatesId,
                        principalTable: "DataGroupTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataGroupTemplateDataTemplate_DataTemplates_DataTemplatesId",
                        column: x => x.DataTemplatesId,
                        principalTable: "DataTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataGroupTemplateTemplate",
                columns: table => new
                {
                    DataGroupTemplatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataGroupTemplateTemplate", x => new { x.DataGroupTemplatesId, x.TemplatesId });
                    table.ForeignKey(
                        name: "FK_DataGroupTemplateTemplate_DataGroupTemplates_DataGroupTemplatesId",
                        column: x => x.DataGroupTemplatesId,
                        principalTable: "DataGroupTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataGroupTemplateTemplate_Templates_TemplatesId",
                        column: x => x.TemplatesId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserData_UserId",
                table: "UserData",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DataGroupTemplateDataTemplate_DataTemplatesId",
                table: "DataGroupTemplateDataTemplate",
                column: "DataTemplatesId");

            migrationBuilder.CreateIndex(
                name: "IX_DataGroupTemplateTemplate_TemplatesId",
                table: "DataGroupTemplateTemplate",
                column: "TemplatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_Users_UserId",
                table: "UserData",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_Users_UserId",
                table: "UserData");

            migrationBuilder.DropTable(
                name: "DataGroupTemplateDataTemplate");

            migrationBuilder.DropTable(
                name: "DataGroupTemplateTemplate");

            migrationBuilder.DropIndex(
                name: "IX_UserData_UserId",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserData");
        }
    }
}
