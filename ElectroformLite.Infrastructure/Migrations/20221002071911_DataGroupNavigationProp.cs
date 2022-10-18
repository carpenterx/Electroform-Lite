using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroformLite.Infrastructure.Migrations
{
    public partial class DataGroupNavigationProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataGroupTemplates_DataGroupTypes_DataGroupTypeId",
                table: "DataGroupTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_DataGroups_DataGroupId",
                table: "UserData");

            migrationBuilder.AlterColumn<Guid>(
                name: "DataGroupId",
                table: "UserData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DataGroupTypeId",
                table: "DataGroupTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DataGroupTemplates_DataGroupTypes_DataGroupTypeId",
                table: "DataGroupTemplates",
                column: "DataGroupTypeId",
                principalTable: "DataGroupTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_DataGroups_DataGroupId",
                table: "UserData",
                column: "DataGroupId",
                principalTable: "DataGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataGroupTemplates_DataGroupTypes_DataGroupTypeId",
                table: "DataGroupTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_DataGroups_DataGroupId",
                table: "UserData");

            migrationBuilder.AlterColumn<Guid>(
                name: "DataGroupId",
                table: "UserData",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DataGroupTypeId",
                table: "DataGroupTemplates",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_DataGroupTemplates_DataGroupTypes_DataGroupTypeId",
                table: "DataGroupTemplates",
                column: "DataGroupTypeId",
                principalTable: "DataGroupTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_DataGroups_DataGroupId",
                table: "UserData",
                column: "DataGroupId",
                principalTable: "DataGroups",
                principalColumn: "Id");
        }
    }
}
