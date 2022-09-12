using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroformLite.Infrastructure.Migrations
{
    public partial class AddExtraDataColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "DataType",
                table: "DataTemplates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataGroupType",
                table: "DataGroupTemplates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataGroupType",
                table: "DataGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataType",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "Placeholder",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "DataTemplates");

            migrationBuilder.DropColumn(
                name: "DataGroupType",
                table: "DataGroupTemplates");

            migrationBuilder.DropColumn(
                name: "DataGroupType",
                table: "DataGroups");
        }
    }
}
