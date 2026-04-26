// using CalorieTracker.Domain.Entities.Product;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace CalorieTracker.Infrastructure.Configurations.Products;
//
// public class ProductConfiguration : IEntityTypeConfiguration<Product>
// {
//     public void Configure(EntityTypeBuilder<Product> builder)
//     {
//         builder.ToTable("Products");
//
//         builder.HasKey(p => p.Id);
//
//         builder.HasOne(p => p.User)
//              .WithMany(u => u.Products)
//              .HasForeignKey(p => p.UserId);
//
//         builder.Property(p => p.ProductName)
//             .HasMaxLength(255)
//             .IsRequired();
//
//         builder.Property(p => p.ProteinPerHundredGram)
//             .IsRequired();
//
//         builder.Property(p => p.FatPerHundredGram)
//             .IsRequired();
//         
//         builder.Property(p => p.CarbsPerHundredGram)
//             .IsRequired();
//
//         builder.Property(p => p.CaloriesPerHundredGram)
//             .IsRequired();
//
//         builder.Property(p => p.VisibilityScope)
//             .IsRequired();
//
//         builder.HasAlternateKey(x => x.ProductName)
//             .HasName("UQ_Products_ProductName");
//     }
// }
