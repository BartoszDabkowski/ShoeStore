using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShoeStore.Migrations
{
    public partial class SeedSizesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Sizes (Name) VALUES (10)"); 
            migrationBuilder.Sql("INSERT INTO Sizes (Name) VALUES (11)"); 
            migrationBuilder.Sql("INSERT INTO Sizes (Name) VALUES (12)"); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Styles WHERE Name IN (10, 11, 12)");
        }
    }
}
