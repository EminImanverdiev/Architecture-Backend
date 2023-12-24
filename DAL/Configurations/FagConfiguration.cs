using Backend_Architecture.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_Architecture.DAL.Configurations
{
    public class FagConfiguration : IEntityTypeConfiguration<Fag>
    {
        public void Configure(EntityTypeBuilder<Fag> builder)
        {
            builder.Property(f => f.Question)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(f => f.Answer)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
