namespace DiscountDemo.Application.CalculateDiscount
{
    [Serializable]
    internal class CustomerDoesNotExistException : Exception
    {
        private const string DefaultMessage = "The customer with id '{0}' does not exist.";

        public CustomerDoesNotExistException(Guid customerId)
            : base(string.Format(DefaultMessage, customerId))
        {
        }

        public CustomerDoesNotExistException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}