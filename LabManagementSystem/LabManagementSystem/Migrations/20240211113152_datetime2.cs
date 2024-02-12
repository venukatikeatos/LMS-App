using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabManagementSystem.Migrations
{
    public partial class datetime2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnteredTime",
                table: "labReports",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EnteredTime",
                table: "labReports",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
