using DiscountDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace DiscountDemo.Adapter.EfDataAccess;

internal static class CustomerSeeding
{
    public static void SeedCustomer(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = new Guid("2FD3575D-E43E-49B1-B05B-16AA2947D1EA"),
                Name = "John Doe",
                Type = CustomerType.Regular
            },
            new Customer
            {
                Id = new Guid("A643CEFD-60FF-44A3-B567-DE7235525257"),
                Name = "John Doe",
                Type = CustomerType.Premium
            },
            new Customer
            {
                Id = new Guid("9625E3F2-31FA-4D3A-81AB-48456372E943"),
                Name = "John Doe",
                Type = CustomerType.Vip
            },
            new Customer
            {
                Id = new Guid("3C2963AB-0424-4E3D-8AEF-AB0C813A08CC"),
                Name = "John Doe",
                Type = (CustomerType)4
            }
        );
    }
}