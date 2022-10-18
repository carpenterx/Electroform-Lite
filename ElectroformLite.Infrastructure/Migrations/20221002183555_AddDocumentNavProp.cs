﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroformLite.Infrastructure.Migrations
{
    public partial class AddDocumentNavProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aliases_Documents_DocumentId",
                table: "Aliases");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentId",
                table: "Aliases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Aliases_Documents_DocumentId",
                table: "Aliases",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aliases_Documents_DocumentId",
                table: "Aliases");

            migrationBuilder.AlterColumn<Guid>(
                name: "DocumentId",
                table: "Aliases",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Aliases_Documents_DocumentId",
                table: "Aliases",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");
        }
    }
}
