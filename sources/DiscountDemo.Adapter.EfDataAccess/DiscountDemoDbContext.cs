using DiscountDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace DiscountDemo.Adapter.EfDataAccess;

public class DiscountDemoDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public DiscountDemoDbContext(DbContextOptions<DiscountDemoDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.SeedCustomer();

        base.OnModelCreating(modelBuilder);
    }
}
