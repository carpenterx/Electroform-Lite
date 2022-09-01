using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroformLite.Infrastructure.Migrations
{
    public partial class FixDataGroupPlaceholder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataGroupType",
                table: "DataGroupTemplates");

            migrationBuilder.RenameColumn(
                name: "DataGroupType",
                table: "DataGroups",
                newName: "DataGroupPlaceholder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataGroupPlaceholder",
                table: "DataGroups",
                newName: "DataGroupType");

            migrationBuilder.AddColumn<string>(
                name: "DataGroupType",
                table: "DataGroupTemplates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
