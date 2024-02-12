using AutoMapper;
using LabManagementSystem.Data;
using LabManagementSystem.DTOs;
using LabManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabManagementSystem.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class LabReportController : Controller
    {
        private readonly LabManagementSystemContext _dbContext;
        private readonly IMapper _mapper;


        public LabReportController(LabManagementSystemContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabReportDTO>>> GetLabReportDetails()
        {
            if (_dbContext.labReports == null)
            {
                return NotFound();
            }

            var labReport = await _dbContext.patients.ToListAsync();
            if (labReport == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<PatientDTO>>(labReport));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LabReportDTO>> GetLabReportDetailsById(int id)
        {
            if (_dbContext.labReports == null)
            {
                return NotFound();
            }
            var labReport = await _dbContext.labReports.FindAsync(id);
            if (labReport == null)
            {
                return NotFound();
            }
            else
            {
                return labReport;
            }
        }

        [HttpPost]
        public async Task<ActionResult<LabReport>> PostLabReportDetails(LabReport labReport)
        {
            _dbContext.labReports.Add(labReport);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLabReportDetails), new { id = labReport.ReportID }, labReport);

        }

       

        [HttpPut("{id}/edit")]
        public async Task<IActionResult> PutLabReportDetails(int id, [FromBody] LabReport labReport)
        {
            if (labReport == null || id != labReport.ReportID)
            {
                return BadRequest("Invalid patient data or ID mismatch");
            }

            try
            {
                var existingLabRecord = await _dbContext.labReports.FindAsync(id);
                if (existingLabRecord == null)
                {
                    return NotFound("labReport is not found");
                }

                _dbContext.Entry(existingLabRecord).CurrentValues.SetValues(labReport);
                await _dbContext.SaveChangesAsync();

                return Ok("labReport updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to update labReport: " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLabReportDetails(int id)
        {
            if (_dbContext.labReports == null)
            {
                return BadRequest();
            }
            var labReport = _dbContext.labReports.FindAsync(id);

            if (labReport == null)
            {
                return NotFound();
            }

            _dbContext.labReports.Remove(await labReport);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}