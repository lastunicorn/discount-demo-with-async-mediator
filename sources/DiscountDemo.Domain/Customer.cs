using System.ComponentModel.DataAnnotations.Schema;

namespace DiscountDemo.Domain;

[Table("Customers")]
public class Customer
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public CustomerType Type { get; set; }
}