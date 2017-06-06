using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FancyText.Migrations
{
    public partial class FAncyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FancyTexts_FancyTextComposition_FancyTextCompositionId",
                table: "FancyTexts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FancyTextComposition",
                table: "FancyTextComposition");

            migrationBuilder.RenameTable(
                name: "FancyTextComposition",
                newName: "FancyTextCompositions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FancyTextCompositions",
                table: "FancyTextCompositions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FancyTexts_FancyTextCompositions_FancyTextCompositionId",
                table: "FancyTexts",
                column: "FancyTextCompositionId",
                principalTable: "FancyTextCompositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FancyTexts_FancyTextCompositions_FancyTextCompositionId",
                table: "FancyTexts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FancyTextCompositions",
                table: "FancyTextCompositions");

            migrationBuilder.RenameTable(
                name: "FancyTextCompositions",
                newName: "FancyTextComposition");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FancyTextComposition",
                table: "FancyTextComposition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FancyTexts_FancyTextComposition_FancyTextCompositionId",
                table: "FancyTexts",
                column: "FancyTextCompositionId",
                principalTable: "FancyTextComposition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
