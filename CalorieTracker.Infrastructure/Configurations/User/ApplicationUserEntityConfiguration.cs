using CalorieTracker.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieTracker.Infrastructure.Configurations.User;

internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
           .HasMaxLength(128)
           .IsRequired();

        builder.Property(x => x.LastName)
           .HasMaxLength(256)
           .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);

        builder.HasIndex(x => x.UserName);

        builder.HasAlternateKey(x => x.Email)
            .HasName("UQ_AspNetUsers_Email");
    }
}
