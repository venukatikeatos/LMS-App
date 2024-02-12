using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabManagementSystem.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientID { get; set; }
        public string? PatientName { get; set; }
        public string? PatientAddress { get; set; }
        public string? PatientGender { get; set; }
        public int PatientAge { get; set; }
        public DateTime PatientDOB { get; set; }

        public ICollection<LabReport> labReport { get; set; }


    }
}
