using CovTestMgmt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovTestMgmt.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(e => e.Phone)
                .IsUnique();
            builder.HasIndex(e => e.Email)
                .IsUnique();
            builder.Property(e => e.Phone)
                .HasMaxLength(4);
        }
    }
}