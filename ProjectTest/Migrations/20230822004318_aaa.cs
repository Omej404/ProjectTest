using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTest.Migrations
{
    public partial class aaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVtitle",
                table: "candidats");

            migrationBuilder.AddColumn<byte[]>(
                name: "CV",
                table: "candidats",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CV",
                table: "candidats");

            migrationBuilder.AddColumn<string>(
                name: "CVtitle",
                table: "candidats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
