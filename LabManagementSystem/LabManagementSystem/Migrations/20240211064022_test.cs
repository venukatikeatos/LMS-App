using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabManagementSystem.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EnteredTime",
                table: "labReports",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "labReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_labReports_PatientID",
                table: "labReports",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_labReports_patients_PatientID",
                table: "labReports",
                column: "PatientID",
                principalTable: "patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_labReports_patients_PatientID",
                table: "labReports");

            migrationBuilder.DropIndex(
                name: "IX_labReports_PatientID",
                table: "labReports");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "labReports");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnteredTime",
                table: "labReports",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }
    }
}
