

using CalorieTracker.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Configurations.User;

internal class ApplicationUserDataConfiguration : IEntityTypeConfiguration<ApplicationUserData>
{
    public void Configure(EntityTypeBuilder<ApplicationUserData> builder)
    {
        builder.ToTable("ApplicationUserData");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithOne(x => x.UserData)
            .HasForeignKey<ApplicationUserData>(x => x.Id);

        builder.HasOne(x => x.ActivityLevel)
            .WithMany(x => x.UserDatas)
            .HasForeignKey(x => x.ActivityLevelId);

        builder.HasOne(x => x.FitnessGoal)
            .WithMany(x => x.UserDatas)
            .HasForeignKey(x => x.FitnessGoalId);

        builder.Property(x => x.Height)
            .IsRequired();

        builder.Property(x => x.Weight)
            .IsRequired();

        builder.Property(x => x.Age)
            .IsRequired();
    }
}
