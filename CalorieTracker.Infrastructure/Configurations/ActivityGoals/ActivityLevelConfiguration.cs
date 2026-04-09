using CalorieTracker.Domain.Entities.ActivityLevel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Configurations.ActivityGoals;

public class ActivityLevelConfiguration : IEntityTypeConfiguration<ActivityLevel>
{
    public void Configure(EntityTypeBuilder<ActivityLevel> builder)
    {
        builder.ToTable("ActivityLevel");

        builder.HasKey(x => x.Id);  

        builder.HasMany(x => x.UserDatas)
            .WithOne(x => x.ActivityLevel)
            .HasForeignKey(x => x.ActivityLevelId);

        builder.Property(x => x.ActivityLevelName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ActivityLevelRate)
            .IsRequired();
    }
}
