using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inshapardaz.Data.Migrations
{
    public partial class RemovedDictionary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Word_Dictionary",
                table: "Word");

            migrationBuilder.DropTable(
                name: "Dictionary");

            migrationBuilder.DropIndex(
                name: "IX_Word_DictionaryId",
                table: "Word");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsPublic = table.Column<bool>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    UserId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Word_DictionaryId",
                table: "Word",
                column: "DictionaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Word_Dictionary",
                table: "Word",
                column: "DictionaryId",
                principalTable: "Dictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
