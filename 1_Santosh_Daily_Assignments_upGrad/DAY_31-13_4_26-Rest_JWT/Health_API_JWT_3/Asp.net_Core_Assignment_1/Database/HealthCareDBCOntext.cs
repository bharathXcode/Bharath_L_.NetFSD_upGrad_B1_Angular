using Asp.net_Core_Assignment_1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_Core_Assignment_1.Database
{
    public class HealthCareDBCOntext:DbContext
    {
        public HealthCareDBCOntext(DbContextOptions<HealthCareDBCOntext> options):base(options) { }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<Prescription> prescriptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Patient!)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor!)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Prescription)
                .WithOne(p => p.Appointment!)
                .HasForeignKey<Prescription>(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Prescription>()
                .HasIndex(p => p.AppointmentId)
                .IsUnique();
            modelBuilder.Entity<Doctor>()
                .Property(d => d.ConsultationFee)
                .HasPrecision(10, 2);
            base.OnModelCreating(modelBuilder);
        }
    }
}
