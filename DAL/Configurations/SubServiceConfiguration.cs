using Backend_Architecture.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_Architecture.DAL.Configurations
{
    public class SubServiceConfiguration : IEntityTypeConfiguration<SubService>
    {
        public void Configure(EntityTypeBuilder<SubService> builder)
        {
            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s=>s.Content)
                .IsRequired()
                .HasMaxLength(200);  
        }
    }
}
