using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabManagementSystem.DTOs
{
    public class PatientDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientID { get; set; }
        public string? PatientName { get; set; }
        public string? PatientAddress { get; set; }
        public string? PatientGender { get; set; }
        public int PatientAge { get; set; }
        public DateTime PatientDOB { get; set; }
    }
}
