using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FancyText.Migrations
{
    public partial class FAncy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FancyTextCompositionId",
                table: "FancyTexts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FancyTextComposition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FancyTextComposition", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FancyTexts_FancyTextCompositionId",
                table: "FancyTexts",
                column: "FancyTextCompositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FancyTexts_FancyTextComposition_FancyTextCompositionId",
                table: "FancyTexts",
                column: "FancyTextCompositionId",
                principalTable: "FancyTextComposition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FancyTexts_FancyTextComposition_FancyTextCompositionId",
                table: "FancyTexts");

            migrationBuilder.DropTable(
                name: "FancyTextComposition");

            migrationBuilder.DropIndex(
                name: "IX_FancyTexts_FancyTextCompositionId",
                table: "FancyTexts");

            migrationBuilder.DropColumn(
                name: "FancyTextCompositionId",
                table: "FancyTexts");
        }
    }
}
