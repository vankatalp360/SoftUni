namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
           : base()
        { }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

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
            builder.Entity<Student>(entity=>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name)
                      .IsRequired(true)
                      .IsUnicode(true)
                      .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                      .IsRequired(false)
                      .IsUnicode(false)
                      .HasColumnType("char(10)");

                entity.Property(e => e.RegisteredOn)
                      .IsRequired(true)
                      .HasColumnType("DATETIME")
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Birthday)
                      .IsRequired(false)
                      .HasColumnType("DATETIME");

                entity.HasMany(s => s.HomeworkSubmissions)
                     .WithOne(h => h.Student)
                     .HasForeignKey(h => h.StudentId)
                     .HasConstraintName("FK_Students_Homeworks");
            });
           
            builder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name)
                      .IsRequired(true)
                      .IsUnicode(true)
                      .HasMaxLength(80);

                entity.Property(e => e.Description)
                      .IsRequired(false)
                      .IsUnicode(true);

                entity.Property(e => e.StartDate)
                      .IsRequired(true)
                      .HasColumnType("DATETIME");

                entity.Property(e => e.EndDate)
                      .IsRequired(true)
                      .HasColumnType("DATETIME");

                entity.Property(e => e.Price)
                      .IsRequired(true)
                      .HasColumnType("decimal(5,2)");

                entity.HasMany(c => c.Resources)
                      .WithOne(r => r.Course)
                      .HasForeignKey(r => r.CourseId)
                      .HasConstraintName("FK_Courses_Resources");

                entity.HasMany(c => c.HomeworkSubmissions)
                      .WithOne(h => h.Course)
                      .HasForeignKey(h => h.CourseId)
                      .HasConstraintName("FK_Courses_Homeworks");
            });

            builder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(e => e.Name)
                      .IsRequired(true)
                      .IsUnicode(true)
                      .HasMaxLength(50);

                entity.Property(e => e.Url)
                      .IsRequired(false)
                      .IsUnicode(false);
            });

            builder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(e => e.Content)
                      .IsRequired(true)
                      .IsUnicode(false);

                entity.Property(e => e.SubmissionTime)
                      .IsRequired(true)
                      .HasColumnType("DATETIME")
                      .HasDefaultValueSql("GETDATE()");
            });

            builder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder.Entity<StudentCourse>(entity =>
            {
                entity.HasOne(sc => sc.Student)
                      .WithMany(s => s.CourseEnrollments)
                      .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentsEnrolled)
                    .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}
