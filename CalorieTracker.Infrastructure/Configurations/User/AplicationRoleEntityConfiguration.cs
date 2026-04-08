using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Configurations.User;

public class AplicationRoleEntityConfiguration : IEntityTypeConfiguration<AplicationRole>
{
    public void Configure(EntityTypeBuilder<AplicationRole> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasAlternateKey(x => x.Name)
            .HasName("UQ_AspNetRoles_Name");

    }
}
