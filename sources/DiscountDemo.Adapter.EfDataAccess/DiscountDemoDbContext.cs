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
}
