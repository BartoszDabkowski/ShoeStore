using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShoeStore.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Brands (Name) VALUES ('Allen Edmonds')");
            migrationBuilder.Sql("INSERT INTO Brands (Name) VALUES ('Paul Evans')");
            migrationBuilder.Sql("INSERT INTO Brands (Name) VALUES ('Johnston & Murphy')");

            migrationBuilder.Sql(@"INSERT INTO Shoes (Name, BrandId) VALUES ('Park Avenue Cap-Toe Oxford', 
                (SELECT ID FROM Brands WHERE Name = 'Allen Edmonds'))");
            migrationBuilder.Sql(@"INSERT INTO Shoes (Name, BrandId) VALUES ('Strand Cap-Toe Oxford',
                (SELECT ID FROM Brands WHERE Name = 'Allen Edmonds'))");
            migrationBuilder.Sql(@"INSERT INTO Shoes (Name, BrandId) VALUES ('Fifth Avenue Cap-Toe Oxford',
                (SELECT ID FROM Brands WHERE Name = 'Allen Edmonds'))");

            migrationBuilder.Sql(@"INSERT INTO Shoes (Name, BrandId) VALUES ('Brando Semi-Brogue Oxford', 
                (SELECT ID FROM Brands WHERE Name = 'Paul Evans'))");
            migrationBuilder.Sql(@"INSERT INTO Shoes (Name, BrandId) VALUES ('Cagney Cap-Toe Oxford',
                (SELECT ID FROM Brands WHERE Name = 'Paul Evans'))");
            migrationBuilder.Sql(@"INSERT INTO Shoes (Name, BrandId) VALUES ('West II Wingtip Oxford',
                (SELECT ID FROM Brands WHERE Name = 'Paul Evans'))");

            migrationBuilder.Sql(@"INSERT INTO Shoes (Name, BrandId) VALUES ('Aldrich II Cap-Toe', 
                (SELECT ID FROM Brands WHERE Name = 'Johnston & Murphy'))");
            migrationBuilder.Sql(@"INSERT INTO Shoes (Name, BrandId) VALUES ('Conrad Cap-Toe Oxford',
                (SELECT ID FROM Brands WHERE Name = 'Johnston & Murphy'))");
            migrationBuilder.Sql(@"INSERT INTO Shoes (Name, BrandId) VALUES ('Mitchell Perfed Wingtip',
                (SELECT ID FROM Brands WHERE Name = 'Johnston & Murphy'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Shoes WHERE Name IN (
                'Park Avenue Cap-Toe Oxford',
                'Strand Cap-Toe Oxford',
                'Fifth Avenue Cap-Toe Oxford',
                'Brando Semi-Brogue Oxford',
                'Cagney Cap-Toe Oxford',
                'West II Wingtip Oxford',
                'Aldrich II Cap-Toe',
                'Conrad Cap-Toe Oxford',
                'Mitchell Perfed Wingtip'
            )");

            migrationBuilder.Sql(@"DELETE FROM Brands WHERE Name IN (
                'Allen Edmonds',
                'Paul Evans',
                'Johnston & Murphy'
            )");
        }
    }
}
