using CalorieTracker.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Configurations.User;

public class AplicationUserRoleEntityConfiguration : IEntityTypeConfiguration<AplicationUserRole>
{
    public void Configure(EntityTypeBuilder<AplicationUserRole> builder)
    {

        builder.HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
    }
}
