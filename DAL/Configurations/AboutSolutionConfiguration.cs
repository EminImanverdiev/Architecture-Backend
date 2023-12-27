using Backend_Architecture.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_Architecture.DAL.Configurations
{
    public class AboutSolutionConfiguration : IEntityTypeConfiguration<AboutSolution>
    {
        public void Configure(EntityTypeBuilder<AboutSolution> builder)
        {
            builder
                .Property(a => a.CountTitle)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a=>a.Count)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}
