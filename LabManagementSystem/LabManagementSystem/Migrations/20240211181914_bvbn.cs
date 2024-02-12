using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabManagementSystem.Migrations
{
    public partial class bvbn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_labReports_patients_PatientID",
                table: "labReports");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "labReports",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_labReports_PatientID",
                table: "labReports",
                newName: "IX_labReports_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_labReports_patients_PatientId",
                table: "labReports",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_labReports_patients_PatientId",
                table: "labReports");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "labReports",
                newName: "PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_labReports_PatientId",
                table: "labReports",
                newName: "IX_labReports_PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_labReports_patients_PatientID",
                table: "labReports",
                column: "PatientID",
                principalTable: "patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
