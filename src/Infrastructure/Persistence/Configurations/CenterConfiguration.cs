using CovTestMgmt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovTestMgmt.Infrastructure.Persistence.Configurations
{
    public class CenterConfiguration : IEntityTypeConfiguration<Center>
    {
        public void Configure(EntityTypeBuilder<Center> builder)
        {
            // builder.Property(t => t.Title)
            //     .HasMaxLength(200)
            //     .IsRequired();

            // builder
            //     .OwnsOne(b => b.Colour);
        }
    }
}