namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder
                .HasKey(p => p.HomeworkId);

            builder
                .Property(p => p.Content)
                .IsUnicode(false);

            builder
                .ToTable("HomeworkSubmissions");

        }
    }
}