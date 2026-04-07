
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Configurations;

public class AplicationRoleEntityConfiguration : IEntityTypeConfiguration<AplicationRoleEntity>
{
    public void Configure(EntityTypeBuilder<AplicationRoleEntity> builder)
    {
        builder.Property(x => x.RoleType)
            .IsRequired();

        builder.HasAlternateKey(x => x.RoleType)
                .HasName("UQ_Users_RoleType");
    }
}
