using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShoeStore.Migrations
{
    public partial class SeedStylesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Oxford')"); 
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Blutcher/Derby')"); 
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Monk Strap')"); 
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Loafer')"); 
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Boot')"); 
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Brogue/Wingtip')"); 
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Plain Toe')"); 
            migrationBuilder.Sql("INSERT INTO Styles (Name) VALUES ('Cap Toe')"); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Styles WHERE Name IN (
                'Oxford',
                'Blutcher/Derby',
                'Monk Strap',
                'Loafer',
                'Boot',
                'Brogue/Wingtip',
                'Plain Toe',
                'Cap Toe'
            )");
        }
    }
}
