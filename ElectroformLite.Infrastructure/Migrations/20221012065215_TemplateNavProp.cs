using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroformLite.Infrastructure.Migrations
{
    public partial class TemplateNavProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AliasTemplateTemplate");

            migrationBuilder.AddColumn<Guid>(
                name: "TemplateId",
                table: "AliasTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AliasTemplates_TemplateId",
                table: "AliasTemplates",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AliasTemplates_Templates_TemplateId",
                table: "AliasTemplates",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AliasTemplates_Templates_TemplateId",
                table: "AliasTemplates");

            migrationBuilder.DropIndex(
                name: "IX_AliasTemplates_TemplateId",
                table: "AliasTemplates");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "AliasTemplates");

            migrationBuilder.CreateTable(
                name: "AliasTemplateTemplate",
                columns: table => new
                {
                    AliasTemplatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AliasTemplateTemplate", x => new { x.AliasTemplatesId, x.TemplatesId });
                    table.ForeignKey(
                        name: "FK_AliasTemplateTemplate_AliasTemplates_AliasTemplatesId",
                        column: x => x.AliasTemplatesId,
                        principalTable: "AliasTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AliasTemplateTemplate_Templates_TemplatesId",
                        column: x => x.TemplatesId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AliasTemplateTemplate_TemplatesId",
                table: "AliasTemplateTemplate",
                column: "TemplatesId");
        }
    }
}
