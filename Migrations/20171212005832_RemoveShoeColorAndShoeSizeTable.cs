using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShoeStore.Migrations
{
    public partial class RemoveShoeColorAndShoeSizeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoeSizes");

            migrationBuilder.DropTable(
                name: "ShoeColor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoeColor",
                columns: table => new
                {
                    ShoeId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeColor", x => new { x.ShoeId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_ShoeColor_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeColor_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoeSizes",
                columns: table => new
                {
                    ShoeId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeSizes", x => new { x.ShoeId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_ShoeSizes_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeColor_ColorId",
                table: "ShoeColor",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSizes_SizeId",
                table: "ShoeSizes",
                column: "SizeId");
        }
    }
}
