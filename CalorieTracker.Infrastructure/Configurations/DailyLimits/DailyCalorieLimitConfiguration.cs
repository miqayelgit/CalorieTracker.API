
using CalorieTracker.Domain.Entities.DailyLimits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Configurations.DailyLimits;

internal class DailyCalorieLimitConfiguration : IEntityTypeConfiguration<DailyCalorieLimit>
{
    public void Configure(EntityTypeBuilder<DailyCalorieLimit> builder)
    {
        builder.ToTable("DailyCalorieLimits");

        builder.HasKey(x => x.Id);

        builder.HasOne(d => d.User)
            .WithMany(u => u.DailyCalorieLimits)
            .HasForeignKey(d => d.UserId);

        builder.Property(x => x.DailyLimit)
            .IsRequired();

        builder.Property(x => x.UsedLimit)
            .IsRequired();

        builder.Property(x => x.RemainingLimit)
            .IsRequired();

        builder.Property(x => x.CreatedDate)
            .IsRequired()
            .HasDefaultValue(new DateTime());
    }
}
