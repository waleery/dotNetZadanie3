using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotNetZadanie3.Migrations
{
    public partial class dodaniePolaDataIWynik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Years",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "wynik",
                table: "Years",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Years");

            migrationBuilder.DropColumn(
                name: "wynik",
                table: "Years");
        }
    }
}
