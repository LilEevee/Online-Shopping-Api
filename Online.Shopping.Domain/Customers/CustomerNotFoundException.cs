namespace Online.Shopping.Domain.Customers
{
    public sealed class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(CustomerId customerId) : base($"Could not find the customer, please supply a valid customerid, ID : {customerId} failed") 
        { }
    }
}
