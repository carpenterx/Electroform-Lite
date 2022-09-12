using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroformLite.Infrastructure.Migrations
{
    public partial class AddAlias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataGroupDocument");

            migrationBuilder.DropTable(
                name: "DataGroupTemplateTemplate");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DataGroupTemplates");

            migrationBuilder.DropColumn(
                name: "DataGroupPlaceholder",
                table: "DataGroups");

            migrationBuilder.CreateTable(
                name: "AliasTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataGroupTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AliasTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AliasTemplates_DataGroupTemplates_DataGroupTemplateId",
                        column: x => x.DataGroupTemplateId,
                        principalTable: "DataGroupTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aliases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AliasTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aliases_AliasTemplates_AliasTemplateId",
                        column: x => x.AliasTemplateId,
                        principalTable: "AliasTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aliases_DataGroups_DataGroupId",
                        column: x => x.DataGroupId,
                        principalTable: "DataGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aliases_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                });

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
                name: "IX_Aliases_AliasTemplateId",
                table: "Aliases",
                column: "AliasTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Aliases_DataGroupId",
                table: "Aliases",
                column: "DataGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Aliases_DocumentId",
                table: "Aliases",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AliasTemplates_DataGroupTemplateId",
                table: "AliasTemplates",
                column: "DataGroupTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_AliasTemplateTemplate_TemplatesId",
                table: "AliasTemplateTemplate",
                column: "TemplatesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aliases");

            migrationBuilder.DropTable(
                name: "AliasTemplateTemplate");

            migrationBuilder.DropTable(
                name: "AliasTemplates");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DataGroupTemplates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataGroupPlaceholder",
                table: "DataGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DataGroupDocument",
                columns: table => new
                {
                    DataGroupsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataGroupDocument", x => new { x.DataGroupsId, x.DocumentsId });
                    table.ForeignKey(
                        name: "FK_DataGroupDocument_DataGroups_DataGroupsId",
                        column: x => x.DataGroupsId,
                        principalTable: "DataGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataGroupDocument_Documents_DocumentsId",
                        column: x => x.DocumentsId,
                        principalTable: "Documents",
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
                name: "IX_DataGroupDocument_DocumentsId",
                table: "DataGroupDocument",
                column: "DocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_DataGroupTemplateTemplate_TemplatesId",
                table: "DataGroupTemplateTemplate",
                column: "TemplatesId");
        }
    }
}
