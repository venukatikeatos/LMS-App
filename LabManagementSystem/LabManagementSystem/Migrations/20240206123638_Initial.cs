using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabManagementSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "labReports",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnteredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeofTest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Results = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labReports", x => x.ReportID);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientAge = table.Column<int>(type: "int", nullable: false),
                    PatientDOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.PatientID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "labReports");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
