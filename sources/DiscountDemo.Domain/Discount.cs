namespace DiscountDemo.Domain;

public class Discount
{
    private readonly Customer customer;
    private readonly float purchaseAmount;

    public float DiscountPercentage { get; private set; }
    
    public float DiscountAmount { get; private set; }

    public Discount(Customer customer, float purchaseAmount)
    {
        this.customer = customer ?? throw new ArgumentNullException(nameof(customer));
        this.purchaseAmount = purchaseAmount;
    }

    public void Calculate()
    {
        DiscountPercentage = CalculateDiscountPercentage();
        DiscountAmount = CalculateDiscountAmount();
    }

    private float CalculateDiscountPercentage()
    {
        return customer.Type switch
        {
            CustomerType.Regular => 0f,
            CustomerType.Premium => 0.05f,
            CustomerType.Vip => 0.10f,
            _ => throw new InvalidCustomerTypeException(customer.Type)
        };
    }

    private float CalculateDiscountAmount()
    {
        return purchaseAmount * DiscountPercentage;
    }
}
