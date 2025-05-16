using Microsoft.AspNetCore.Mvc;

namespace DiscountDemo.Presentation.Controllers;

public class DiscountRequestDto
{
    /// <summary>
    /// The id of the customer for which to calculate the discount.
    /// </summary>
    [FromQuery]
    public Guid CustomerId { get; set; }

    /// <summary>
    /// The value of the purchase for which to calculate the amount.
    /// This is necessary for returning the actual discount amount.
    /// </summary>
    [FromQuery]
    public float PurchaseAmount { get; set; }
}
