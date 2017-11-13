namespace P01_HospitalDatabase
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
           : base()
        { }

        public HospitalContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.Property(e => e.FirstName)
                                    .IsRequired()
                                    .IsUnicode(true)
                                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                                    .IsRequired()
                                    .IsUnicode(true)
                                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                                   .IsRequired()
                                   .IsUnicode(true)
                                    .HasMaxLength(250);

                entity.Property(e => e.Email)
                                   .IsRequired()
                                   .IsUnicode(false)
                                    .HasMaxLength(80);

                entity.Property(e => e.HasInsurance)
                                    .HasDefaultValue(true);
            });

            builder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.Property(e => e.Name)
                                    .IsRequired()
                                    .IsUnicode(true)
                                    .HasMaxLength(100);

                entity.Property(e => e.Specialty)
                                    .IsRequired()
                                    .IsUnicode(true)
                                    .HasMaxLength(100);
            });

            builder.Entity<Visitation>(entity =>
            {
                entity.HasKey(e => e.VisitationId);

                entity.Property(e => e.Comments)
                                    .IsRequired(false)
                                    .IsUnicode(true)
                                    .HasMaxLength(250);

                entity.Property(e => e.Date)
                                    .HasColumnName("VisitationDate")
                                    .IsRequired()
                                    .HasColumnType("DATETIME2")
                                    .HasDefaultValueSql("GETDATE()");

                entity.HasOne(v => v.Patient)
                      .WithMany(p => p.Visitations)
                      .HasForeignKey(v => v.PatientId)
                      .HasConstraintName("FK_Visitations_Patients");

                entity.HasOne(v => v.Doctor)
                      .WithMany(p => p.Visitations)
                      .HasForeignKey(v => v.DoctorId)
                      .HasConstraintName("FK_Visitations_Doctors");
            });

            builder.Entity<Diagnose>(entity =>
            {
                entity.HasKey(e => e.DiagnoseId);

                entity.Property(e => e.Name)
                                    .IsRequired()
                                    .IsUnicode(true)
                                    .HasMaxLength(50);

                entity.Property(e => e.Comments)
                                    .IsRequired(false)
                                    .IsUnicode(true)
                                    .HasMaxLength(250);

                entity.HasOne(d => d.Patient)
                      .WithMany(p => p.Diagnoses)
                      .HasForeignKey(d => d.PatientId)
                      .HasConstraintName("FK_Diagnoses_Patients");
            });

            builder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.MedicamentId);

                entity.Property(e => e.Name)
                                    .IsRequired()
                                    .IsUnicode(true)
                                    .HasMaxLength(50);
            });

            builder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new { pm.PatientId, pm.MedicamentId });

                entity.HasOne(e => e.Medicament)
                       .WithMany(m => m.Prescriptions)
                       .HasForeignKey(e => e.MedicamentId);

                entity.HasOne(e => e.Patient)
                       .WithMany(p => p.Prescriptions)
                       .HasForeignKey(e => e.PatientId);
            });
        }
    }
}
