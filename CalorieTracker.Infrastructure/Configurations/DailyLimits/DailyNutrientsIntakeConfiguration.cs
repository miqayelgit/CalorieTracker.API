//
//
// using Microsoft.EntityFrameworkCore;
// using CalorieTracker.Domain.Entities.DailyLimits;
//
// namespace CalorieTracker.Infrastructure.Configurations.DailyLimits;
//
// public class DailyNutrientsIntakeConfiguration : IEntityTypeConfiguration<DailyNutrientsIntakeAmount>
// {
//     public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DailyNutrientsIntakeAmount> builder)
//     {
//         builder.ToTable("DailyNutrientsIntakeAmounts");
//
//         builder.HasKey(x => x.Id);
//
//         builder.HasOne(x => x.User)
//             .WithMany(u => u.DailyNutrientsIntakeAmounts)
//             .HasForeignKey(x => x.UserId);
//
//         builder.Property(x => x.Protein)
//             .IsRequired();
//
//         builder.Property(x => x.Fat)
//             .IsRequired();
//
//         builder.Property(x => x.Carbs)
//             .IsRequired();
//     }
// }
