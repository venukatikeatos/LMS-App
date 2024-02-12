using AutoMapper;
using LabManagementSystem.Data;
using LabManagementSystem.DTOs;
using LabManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LabManagementSystem.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {

        private readonly LabManagementSystemContext _dbContext;
        private readonly IMapper _mapper;

        public PatientController(LabManagementSystemContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatientDetails()
        {
            var patient = await _dbContext.patients.ToListAsync();
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<PatientDTO>>(patient));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatientDetailsById(int id)
        {
            if (_dbContext.patients == null)
            {
                return NotFound();
            }
            var patient = await _dbContext.patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                return patient;
            }
        }

        [HttpPost]
        public async Task<ActionResult<PatientDTO>> PostPatientDetails(PatientDTO patientDTO)
        {

            // Map PatientDTO to Patient entity
            var patient = _mapper.Map<Patient>(patientDTO);

            // Add Patient entity to the database context
            _dbContext.patients.Add(patient);
            await _dbContext.SaveChangesAsync();

            // Map the created Patient entity back to PatientDTO
            var createdPatientDTO = _mapper.Map<PatientDTO>(patient);

            // Return the created PatientDTO with appropriate HTTP status code and location header
            return CreatedAtAction(nameof(GetPatientDetails), new { id = createdPatientDTO.PatientID }, createdPatientDTO);

        }

        [HttpPut("{id}/edit")]
        public async Task<IActionResult> PutPatientDetails(int id, PatientDTO patientDTO)
        {
            // Check if the provided patient DTO is null
            if (patientDTO == null)
            {
                return BadRequest("Invalid patient data.");
            }

            var patient = await _dbContext.patients.FindAsync(id); // Find the patient entity by ID

            // If the patient with the provided ID is not found, return a NotFound response
            if (patient == null)
            {
                return NotFound("Patient not found.");
            }

            // Update the patient entity with the data from the DTO
            patient.PatientName = patientDTO.PatientName;
            patient.PatientAddress = patientDTO.PatientAddress;
            patient.PatientGender = patientDTO.PatientGender;
            patient.PatientAge = patientDTO.PatientAge;
            patient.PatientDOB = patientDTO.PatientDOB;

            try
            {
                _dbContext.Entry(patient).State = EntityState.Modified; // Update the state of the patient entity to Modified
                await _dbContext.SaveChangesAsync();   // Save changes to the database
                return Ok("Patient details updated successfully.");
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency conflicts
                if (!PatientAvailable(id))
                {
                    return NotFound("Patient not found.");
                }
                else
                {
                    throw;
                }
            }


        }
        private bool PatientAvailable(int id)
        {
            return (_dbContext.patients?.Any(p => p.PatientID == id)).GetValueOrDefault();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePatientDetails(int id)
        {
            try
            {
                // Check if the patient with the provided ID exists
                var patient = await _dbContext.patients.FindAsync(id);
                if (patient == null)
                {
                    return NotFound("Patient not found.");
                }

                // Remove the patient entity from the DbContext
                _dbContext.patients.Remove(patient);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return Ok("Patient deleted successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the delete operation
                return StatusCode(500, "An error occurred while deleting the patient.");
            }
        }
    }
}
