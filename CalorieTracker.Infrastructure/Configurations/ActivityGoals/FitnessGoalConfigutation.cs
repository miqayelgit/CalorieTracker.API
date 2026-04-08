
using CalorieTracker.Domain.Entities.ActivityGoals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Configurations.ActivityGoals;

public class FitnessGoalConfigutation : IEntityTypeConfiguration<FitnessGoal>
{
    public void Configure(EntityTypeBuilder<FitnessGoal> builder)
    {
        builder.ToTable("FitnessGoals");

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.UserDatas)
            .WithOne(u => u.FitnessGoal)
            .HasForeignKey(x => x.FitnessGoalId);

        builder.Property(x => x.GoalName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ProteinPercent)
            .IsRequired();

        builder.Property(x => x.FatPercent)
            .IsRequired();

        builder.Property(x => x.CarbsPercent)
            .IsRequired();
    }
}
