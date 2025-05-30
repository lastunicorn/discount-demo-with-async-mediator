namespace DiscountDemo.Presentation.Models;

public class DiscountResponseDto
{
    /// <summary>
    /// The discount percentage value.
    /// The total discount is calculated as a base discount based on the client's type cumulated
    /// with other discounts that may be applied because of other conditions.
    /// </summary>
    public float DiscountPercentage { get; set; }

    /// <summary>
    /// The discount value calculated for the requested purchase amount.
    /// </summary>
    public float DiscountAmount { get; set; }
}
