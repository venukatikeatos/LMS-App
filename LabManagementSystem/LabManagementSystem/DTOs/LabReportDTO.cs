using System.ComponentModel.DataAnnotations;

namespace LabManagementSystem.DTOs
{
    public class LabReportDTO
    {
        [Key]
        public int ReportID { get; set; }
        public string? TestType { get; set; }
        public DateTime EnteredTime { get; set; }
        public DateTime TimeofTest { get; set; }
        public string? Results { get; set; }
        public int PatientId { get; set; }
       
    }
}
