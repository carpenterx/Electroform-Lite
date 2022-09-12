using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroformLite.Infrastructure.Migrations
{
    public partial class AddDocumentDataGroupRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_DataGroupDocument_DocumentsId",
                table: "DataGroupDocument",
                column: "DocumentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataGroupDocument");
        }
    }
}
