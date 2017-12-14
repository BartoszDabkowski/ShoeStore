using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShoeStore.Migrations
{
    public partial class SeedColorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Colors (Name) VALUES ('Black')"); 
            migrationBuilder.Sql("INSERT INTO Colors (Name) VALUES ('Brown')"); 
            migrationBuilder.Sql("INSERT INTO Colors (Name) VALUES ('Walnut')"); 
            migrationBuilder.Sql("INSERT INTO Colors (Name) VALUES ('Oxblood')"); 
            migrationBuilder.Sql("INSERT INTO Colors (Name) VALUES ('Navy')"); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Colors WHERE Name IN (
                'Black',
                'Brown',
                'Walnut',
                'Oxblood',
                'Navy'
            )");
        }
    }
}
