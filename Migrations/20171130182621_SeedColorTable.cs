using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShoeStore.Migrations
{
    public partial class SeedColorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Black')"); 
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Brown')"); 
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Walnut')"); 
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Oxblood')"); 
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Navy')"); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Styles WHERE Name IN (
                'Black',
                'Brown',
                'Walnut',
                'Oxblood',
                'Navy'
            )");
        }
    }
}
