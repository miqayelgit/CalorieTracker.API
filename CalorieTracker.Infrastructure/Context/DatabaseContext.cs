using System.Reflection;
using CalorieTracker.Domain.Entities.Product;
using CalorieTracker.Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Infrastructure.Context;

public class DatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public DbSet<Product> Product { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}