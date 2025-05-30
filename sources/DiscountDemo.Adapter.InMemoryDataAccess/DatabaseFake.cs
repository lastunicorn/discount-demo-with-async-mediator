using DiscountDemo.Domain;

namespace DiscountDemo.Adapter.DataAccess;

internal static class DatabaseFake
{
    public static List<Customer> Customers { get; } =
    [
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
    ];
}