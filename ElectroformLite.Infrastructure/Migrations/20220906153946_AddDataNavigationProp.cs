using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroformLite.Infrastructure.Migrations
{
    public partial class AddDataNavigationProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_DataTemplates_DataTemplateId",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "Placeholder",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "DataTypeValue",
                table: "DataTemplates");

            migrationBuilder.AlterColumn<Guid>(
                name: "DataTemplateId",
                table: "UserData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_DataTemplates_DataTemplateId",
                table: "UserData",
                column: "DataTemplateId",
                principalTable: "DataTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_DataTemplates_DataTemplateId",
                table: "UserData");

            migrationBuilder.AlterColumn<Guid>(
                name: "DataTemplateId",
                table: "UserData",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "UserData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Placeholder",
                table: "UserData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataTypeValue",
                table: "DataTemplates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_DataTemplates_DataTemplateId",
                table: "UserData",
                column: "DataTemplateId",
                principalTable: "DataTemplates",
                principalColumn: "Id");
        }
    }
}
