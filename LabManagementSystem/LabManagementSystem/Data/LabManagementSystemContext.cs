using LabManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LabManagementSystem.Data
{
    public class LabManagementSystemContext : DbContext
    {
        public LabManagementSystemContext(DbContextOptions<LabManagementSystemContext> options) : base(options)
        {
            
        }
        public DbSet<Patient> patients { get; set; }
        public DbSet<LabReport> labReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LabReport>().Property(l => l.EnteredTime).HasColumnType("date");
            modelBuilder.Entity<LabReport>().HasOne(l => l.patient).WithMany(p => p.labReport).HasForeignKey(l => l.PatientId);
        }
        // modelBuilder.Entity<LabReport>().Property(l => l.TimeofTest).HasColumnType("time");
    
    }
}
