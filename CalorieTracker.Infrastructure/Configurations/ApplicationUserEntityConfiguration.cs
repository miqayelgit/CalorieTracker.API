

using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUserEntity>
{
    public void Configure(EntityTypeBuilder<ApplicationUserEntity> builder)
    {
        builder.Property(x => x.FirstName)
           .HasMaxLength(128)
           .IsRequired();

        builder.Property(x => x.LastName)
           .HasMaxLength(256)
           .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);
    }
}
