using AsyncMediator;

namespace DiscountDemo.Application.Discount;

public class DiscountCriteria
{
    public Guid CustomerId { get; set; }

    public float PurchaseAmount { get; set; }
}
