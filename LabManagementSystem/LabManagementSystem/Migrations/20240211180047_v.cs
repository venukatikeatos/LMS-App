using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabManagementSystem.Migrations
{
    public partial class v : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "labReports");

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

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "labReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
