
using CalorieTracker.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Configurations;

public class AplicationUserRoleEntityConfiguration : IEntityTypeConfiguration<AplicationUserRoleEntity>
{
    public void Configure(EntityTypeBuilder<AplicationUserRoleEntity> builder)
    {
    }
}
