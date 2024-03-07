using AutoMapper;
using LabManagementSystem.DTOs;
using LabManagementSystem.Models;

namespace LabManagementSystem.Utilities
{
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<PatientDTO, Patient>(); // Define mapping from PatientDTO to Patient
                CreateMap<Patient, PatientDTO>();
                CreateMap<LabReportDTO, LabReport>();
                CreateMap<LabReport, LabReportDTO>();

        }
    }
    
}
