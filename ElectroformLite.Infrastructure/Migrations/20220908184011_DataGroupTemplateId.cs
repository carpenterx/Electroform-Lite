using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroformLite.Infrastructure.Migrations
{
    public partial class DataGroupTemplateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataGroups_DataGroupTemplates_DataGroupTemplateId",
                table: "DataGroups");

            migrationBuilder.AlterColumn<Guid>(
                name: "DataGroupTemplateId",
                table: "DataGroups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DataGroups_DataGroupTemplates_DataGroupTemplateId",
                table: "DataGroups",
                column: "DataGroupTemplateId",
                principalTable: "DataGroupTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataGroups_DataGroupTemplates_DataGroupTemplateId",
                table: "DataGroups");

            migrationBuilder.AlterColumn<Guid>(
                name: "DataGroupTemplateId",
                table: "DataGroups",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_DataGroups_DataGroupTemplates_DataGroupTemplateId",
                table: "DataGroups",
                column: "DataGroupTemplateId",
                principalTable: "DataGroupTemplates",
                principalColumn: "Id");
        }
    }
}
