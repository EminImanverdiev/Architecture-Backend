using Backend_Architecture.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend_Architecture.DAL.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(p=>p.Title)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(p => p.Content)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
